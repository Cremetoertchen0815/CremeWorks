﻿using CremeWorks.App;
using CremeWorks.App.Data;
using CremeWorks.App.Data.Compatibility;
using CremeWorks.App.Dialogs;
using CremeWorks.App.Properties;
using CremeWorks.Common;
using CremeWorks.Networking;
using System.Runtime.InteropServices;

namespace CremeWorks
{
    public partial class MainForm : Form, IDataParent
    {
        private Database _database;
        private MidiManager _midiManager;
        private readonly SoloManager _soloManager;
        private PlaylistListBoxItem? _activeEntry = null;
        private NetworkingServer _server;
        private readonly Metronome _metronome;
        private bool _sendMetronomeData = false;
        private int _secondsCounter = 0;

        #region External
        private const int EM_LINESCROLL = 0x00B6;
        [DllImport("user32.dll")]
        private static extern int SetScrollPos(IntPtr hWnd, int nBar,
                               int nPos, bool bRedraw);
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg,
                                       int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern int GetScrollPos(IntPtr hWnd, int nBar);
        #endregion


        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            _database = new Database();
            _midiManager = new MidiManager(this);
            _midiManager.ConnectionChanged += x => startMIDIToolStripMenuItem.Checked = x;
            _midiManager.ControllerActionExecuted += ExecuteAction;

            _server = new NetworkingServer();
            _server.UserJoined += _server_UserJoined;
            _server.MessageReceived += _server_MessageReceived;

            _soloManager = new SoloManager(this);
            _soloManager.SoloStateChanged += _soloManager_SoloStateChanged;


            _metronome = new Metronome();
            _metronome.Tick += TickMetronome;

            syncToolStripMenuItem.Checked = Settings.Default.SyncToCloud;
            if (Settings.Default.Recents == null)
            {
                Settings.Default.Recents = new();
                Settings.Default.Save();
            }
            foreach (var item in Settings.Default.Recents)
            {
                var menuItem = new ToolStripMenuItem(item);
                menuItem.Tag = item;
                menuItem.Click += openRecentToolStripMenuItem_Click;
                openRecentToolStripMenuItem.DropDownItems.Add(menuItem);
            }

            UpdateConcert();
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e) => new MidiSetUp(this).ShowDialog();
        private void footSwitchToolStripMenuItem_Click(object sender, EventArgs e) => new FootSwitchConfig(this).ShowDialog();

        private void startMIDIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!startMIDIToolStripMenuItem.Checked)
            {
                _midiManager.Connect();
                _midiManager.UpdateMatrix();
            }
            else
            {
                _midiManager.SendAllNotesOff();
                _midiManager.Disconnect();
            }
        }

        private void UpdatePlaylist()
        {
            var playlistEntry = (SetsListBoxItem)boxSet.SelectedItem!;
            _server.SendToAll(MessageTypeEnum.CONCERT_NAME, playlistEntry.ToString());

            playList.Items.Clear();
            var sortedSongEntries = new List<(IPlaylistEntry entry, int index)>();

            if (playlistEntry.playlist is null)
            {
                //Add backlog songs
                sortedSongEntries = _database.Songs.OrderBy(x => x.Value.Artist).ThenBy(x => x.Value.Title).Select((x, i) => ((IPlaylistEntry)new SongPlaylistEntry(x.Key), i)).ToList();
            }
            else
            {
                //Add playlist songs
                int songIndex = 0;
                foreach (var song in playlistEntry.playlist.Elements)
                {
                    sortedSongEntries.Add((song, songIndex));
                    if (song is SongPlaylistEntry) songIndex++;
                }
            }

            //Add playlist to listbox
            var inSet = playlistEntry.playlist is not null;
            playList.Items.AddRange(sortedSongEntries.Select(x => new PlaylistListBoxItem(x.entry.GetCommonInformation(_database, x.index, inSet), x.entry)).ToArray());

            _server.SendToAll(MessageTypeEnum.SET_DATA, GetClientSet());
            _activeEntry = null;
            if (playList.Items.Count > 0) playList.SelectedIndex = 0;
            UpdateSong();
        }

        private void UpdateSong()
        {
            songTitle.Text = string.Empty;
            songLyrics.Text = string.Empty;
            songKey.Text = "";
            songTempo.Text = "";
            btnTimeReset.Enabled = false;
            btnTimeStore.Enabled = false;
            lightCue.Items.Clear();
            _server.SendToAll(MessageTypeEnum.CURRENT_SONG, _activeEntry?.Info ?? PlaylistEntryCommonInfo.None);


            songTime.Text = "00:00 (+00:00)";
            songTime.ForeColor = Color.Black;
            songTimer.Stop();
            _secondsCounter = 0;

            if (_activeEntry == null)
            {
                _server.SendToAll(MessageTypeEnum.CLICK_INFO, "off");
                _metronome.Stop();
                return;
            }

            songTitle.Text = _activeEntry.Info.Title;
            songLyrics.Text = _activeEntry.Info.Lyrics;
            songKey.Text = _activeEntry.Info.Key;
            songTempo.Text = _activeEntry.Info.Tempo.ToString() + " BPM";
            _metronome.Start(_activeEntry.Info.Tempo);
            btnTimeReset.Enabled = true;
            btnTimeStore.Enabled = true;
            lightCue.Items.AddRange(_activeEntry.Info.Cues.Select((x, i) => new CueListBoxItem(i, x, _database.LightingCues[x.CueId].Name)).ToArray());
            songTimer.Start();

            //Configure shit
            _sendMetronomeData = true;
            _midiManager.UpdateMatrix();
            _soloManager.Active = false;
            if (_activeEntry.Entry.Type == PlaylistEntryType.Marker) _midiManager.SendAllNotesOff();

            //Load default cue patch
            if (lightCue.Items.Count > 0) lightCue.SelectedIndex = 0;
        }

        public void ExecuteAction(ControllerActionType type, bool? enable)
        {
            bool chk = enable ?? true;
            switch (type)
            {
                case ControllerActionType.PrevSong:
                    if (chk && playList.SelectedIndex > 0) playList.SelectedIndex--;
                    break;
                case ControllerActionType.NextSong:
                    if (chk && playList.SelectedIndex < playList.Items.Count - 1) playList.SelectedIndex++;
                    break;
                case ControllerActionType.ScrollUp:
                    if (!chk) break;
                    SetScrollPos(songLyrics.Handle, 1, -10, true);
                    SendMessage(songLyrics.Handle, EM_LINESCROLL, 0, -10);
                    break;
                case ControllerActionType.ScrollDown:
                    if (!chk) break;
                    SetScrollPos(songLyrics.Handle, 1, 10, true);
                    SendMessage(songLyrics.Handle, EM_LINESCROLL, 0, 10);
                    break;
                case ControllerActionType.CueBack:
                    if (lightCue.SelectedIndex > 0) lightCue.SelectedIndex--;
                    break;
                case ControllerActionType.CueAdvance:
                    if (lightCue.SelectedIndex < lightCue.Items.Count - 1) lightCue.SelectedIndex++;
                    break;
            }
        }

        private void playList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _activeEntry = playList.SelectedIndex >= 0 ? playList.SelectedItem as PlaylistListBoxItem : null;
            UpdateSong();
        }

        private void New(object sender, EventArgs e)
        {
            _database = new Database();
            UpdateConcert();
        }

        private void UpdateConcert(bool onlyUpdateTitle = false)
        {
            string tit = _database.FilePath is null or "" ? "Untitled" : _database.FilePath;
            string titClean = _database.FilePath is null or "" ? "Untitled" : Path.GetFileNameWithoutExtension(_database.FilePath);
            Text = "CremeWorks Stage Controller - " + tit;
            if (onlyUpdateTitle) return;

            //Update set ListBox
            var prevSelItem = (playList.SelectedItem as SetsListBoxItem)?.playlist;
            var newItems = new List<SetsListBoxItem> { new(null) };
            newItems.AddRange(_database.Playlists.OrderByDescending(x => x.Date).Select(x => new SetsListBoxItem(x)).ToArray());
            var newSelItem = newItems.FirstOrDefault(x => x.playlist == prevSelItem) ?? newItems[0];
            boxSet.Items.Clear();
            boxSet.Items.AddRange(newItems.ToArray());
            boxSet.SelectedItem = newSelItem;

            UpdatePlaylist();
            playList.SelectedIndex = -1;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            try
            {
                _database = FileParser.ParseFile(openFileDialog1.FileName) ?? throw new Exception("Deserializer is null!");

                // Update recents list
                if (!Settings.Default.Recents.Contains(openFileDialog1.FileName))
                {
                    Settings.Default.Recents.Add(openFileDialog1.FileName);
                    Settings.Default.Save();
                    var item = new ToolStripMenuItem(openFileDialog1.FileName);
                    item.Tag = openFileDialog1.FileName;
                    item.Click += openRecentToolStripMenuItem_Click;
                    openRecentToolStripMenuItem.DropDownItems.Add(item);
                }
            }
            catch (Exception)
            {
                _database = new Database();
                MessageBox.Show("Database file is corrupted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateConcert();
        }

        private void Save(object sender, EventArgs e)
        {
            if (_database.FilePath == null || _database.FilePath == string.Empty)
            {
                if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
                _database.FilePath = saveFileDialog1.FileName;
            }
            FileParser.SaveFile(_database.FilePath, _database);
        }

        private void SaveAs(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            _database.FilePath = saveFileDialog1.FileName;
            FileParser.SaveFile(_database.FilePath, _database);
            UpdateConcert(true);
        }

        private void lightControllerToolStripMenuItem_Click(object sender, EventArgs e) => new LightCueManager(this).ShowDialog();

        private void playlistsToolStripMenuItem_Click(object sender, EventArgs e) => new PlaylistEditor(this).ShowDialog();

        private async void lightCue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_activeEntry is null) return;
            _server.SendToAll(MessageTypeEnum.CUE_INDEX, lightCue.SelectedIndex.ToString());

            //Send light cue
            var cueItem = lightCue.SelectedItem as CueListBoxItem;
            if (cueItem is null || !Database.LightingCues.TryGetValue(cueItem.Cue.CueId, out var cue)) return;
            await _midiManager.SendToLighting(cue.NoteValue);
        }

        private void btnChatSend_Click(object sender, EventArgs e)
        {
            var msg = "Server: " + chatInput.Text;
            chatBox.Items.Add(msg);
            _server.SendToAll(MessageTypeEnum.CHAT_MESSAGE, msg);
            chatInput.Text = string.Empty;
            chatBox.TopIndex = chatBox.Items.Count - 1;
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (startToolStripMenuItem.Checked)
            {
                _server.Stop();
                startToolStripMenuItem.Checked = false;
            }
            else
            {
                var addr = Prompt.ShowDialog("Please enter the broadcast address of the network you want to use:", "Open Server", "255.255.255.255");
                if (addr == null) return;
                _server.Start(addr);
                startToolStripMenuItem.Checked = true;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) => _server.Stop();


        private void _server_UserJoined(NetworkConnection con)
        {
            string tit = Database.FilePath is null or "" ? "Untitled" : Path.GetFileNameWithoutExtension(Database.FilePath);
            con.SendMessage(MessageTypeEnum.CONCERT_NAME, tit);
            con.SendMessage(MessageTypeEnum.SET_DATA, GetClientSet());
            con.SendMessage(MessageTypeEnum.CURRENT_SONG, _activeEntry?.Info ?? PlaylistEntryCommonInfo.None);
            con.SendMessage(MessageTypeEnum.CUE_INDEX, lightCue.SelectedIndex.ToString());
        }

        private string[] GetClientSet() => playList.Items.OfType<PlaylistListBoxItem>().Select(x => x.Info.Header).ToArray();

        private void _server_MessageReceived(MessageTypeEnum type, string data, NetworkConnection con) => Invoke(new Action(() =>
        {
            switch (type)
            {
                case MessageTypeEnum.CHAT_MESSAGE:
                    var msg = $"{con.Name}: {data}";
                    chatBox.Items.Add(msg);
                    _server.SendToAll(MessageTypeEnum.CHAT_MESSAGE, msg);
                    chatBox.TopIndex = chatBox.Items.Count - 1;
                    LightUpChatbox();
                    break;
                default:
                    break;
            }
        }));

        private async void TickMetronome()
        {
            if (_sendMetronomeData)
            {
                byte? metronomeVal = _activeEntry?.Entry is SongPlaylistEntry se && Database.Songs.TryGetValue(se.SongId, out var song) && song.Click ? song.Tempo : null;
                _server.SendToAll(MessageTypeEnum.CLICK_INFO, metronomeVal.ToString() ?? "off");
                _sendMetronomeData = false;
            }
            await Task.Delay(15);
            boxTempo.BackColor = Color.Navy;
            await Task.Delay(50);
            boxTempo.BackColor = Color.White;
        }

        private void exportSetToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (boxSet.SelectedItem is null || csvExportSaveFile.ShowDialog() != DialogResult.OK) return;
            var set = (boxSet.SelectedItem as SetsListBoxItem)?.playlist;
            //If no set is selected, select backlog
            if (set is null)
            {
                set = new Playlist
                {
                    Name = "Backlog",
                    Date = DateOnly.FromDateTime(DateTime.Now)
                };
                set.Elements.AddRange(Database.Songs.OrderBy(x => x.Value.Artist).ThenBy(x => x.Value.Title).Select(x => new SongPlaylistEntry(x.Key)));
            }

            try
            {
                File.WriteAllText(csvExportSaveFile.FileName, set.ToCsv(Database));
            }
            catch (Exception)
            {
                MessageBox.Show("Selected file cannot be saved to!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _soloManager_SoloStateChanged(bool enabled)
        {
            songSolo.ForeColor = enabled ? Color.Green : Color.Red;
            songSolo.Text = enabled ? "On" : "Off";
        }

        private bool _chatboxLit = false;

        public Database Database => _database;
        public MidiManager MidiManager => _midiManager;
        public SoloManager SoloManager => _soloManager;
        public NetworkingServer NetworkManager => _server;
        public IPlaylistEntry? CurrentEntry => _activeEntry?.Entry;


        private async void LightUpChatbox()
        {
            if (_chatboxLit) return;
            _chatboxLit = true;
            var original = chatBox.BackColor;
            chatBox.BackColor = Color.Lime;
            await Task.Delay(500);
            chatBox.BackColor = original;
            _chatboxLit = false;

        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void songsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SongList(this).ShowDialog();
            UpdatePlaylist();
        }

        private void defaultMIDIRoutingToolStripMenuItem_Click(object sender, EventArgs e) => new SongRoutingEditor(this, null).ShowDialog();

        private void boxSet_SelectedIndexChanged(object sender, EventArgs e) => UpdatePlaylist();

        private void patchesToolStripMenuItem_Click(object sender, EventArgs e) => new PatchEditor(this).ShowDialog();

        private void soloModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SoloModeSetup(this).ShowDialog();
            _soloManager.UpdateState();
        }

        private void syncToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            Settings.Default.SyncToCloud = syncToolStripMenuItem.Checked;
            Settings.Default.Save();
        }

        private void cWCDateiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cwcImportOpenFile.ShowDialog() != DialogResult.OK) return;
            Concert? concert = null;
            try
            {
                concert = Concert.LoadFromFile(cwcImportOpenFile.FileName);
            }
            catch (Exception)
            {
            }

            if (concert == null)
            {
                MessageBox.Show("Invalid concert file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dialog = new ConcertImportDialog(concert, _database, Path.GetFileNameWithoutExtension(cwcImportOpenFile.FileName));
            if (dialog.ShowDialog() != DialogResult.OK) return;
            if (!ConcertConverter.Convert(_database, concert, dialog.Config, out var errorMsg))
            {
                MessageBox.Show(errorMsg, "Error converting concert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateConcert();
        }

        private void allNotesOffToolStripMenuItem_Click(object sender, EventArgs e) => _midiManager.SendAllNotesOff();

        private void openRecentToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            if (item == null) return;
            var path = item.Tag as string;

            if (!File.Exists(path))
            {
                if (Settings.Default.Recents.Contains(path))
                {
                    Settings.Default.Recents.Remove(path);
                    Settings.Default.Save();
                }
                openRecentToolStripMenuItem.DropDownItems.Remove(item);
                MessageBox.Show("File not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _database = FileParser.ParseFile(path) ?? throw new Exception("Deserializer is null!");
            }
            catch (Exception)
            {
                if (Settings.Default.Recents.Contains(path))
                {
                    Settings.Default.Recents.Remove(path);
                    Settings.Default.Save();
                }
                openRecentToolStripMenuItem.DropDownItems.Remove(item);
                _database = new Database();
                MessageBox.Show("Database file is corrupted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateConcert();
        }

        private void songTimer_Tick(object sender, EventArgs e)
        {
            if (_activeEntry is null || _activeEntry.Entry.Type != PlaylistEntryType.Song) return;
            var songEntry = (SongPlaylistEntry)_activeEntry.Entry;
            var song = _database.Songs[songEntry.SongId];
            var time = TimeSpan.FromSeconds(++_secondsCounter);
            var diff = time - TimeSpan.FromSeconds(song.ExpectedDurationSeconds);
            songTime.Text = $"{time:mm\\:ss} ({(diff.TotalSeconds < 0 ? "-" : "+")}{diff:mm\\:ss})";
            songTime.ForeColor = diff.TotalSeconds > 0 && song.ExpectedDurationSeconds > 0 ? Color.Red : Color.Black;
        }

        private void btnTimeReset_Click(object sender, EventArgs e)
        {
            songTimer.Stop();
            _secondsCounter = 0;

            var expectedSec = _activeEntry is null || _activeEntry.Entry.Type != PlaylistEntryType.Song ? 0 : _database.Songs[((SongPlaylistEntry)_activeEntry.Entry).SongId].ExpectedDurationSeconds;
            var expectedDuration = TimeSpan.FromSeconds(-expectedSec);
            songTime.Text = $"00:00 ({(expectedSec == 0 ? "+" : "-")}{expectedDuration:mm\\:ss})";
            songTime.ForeColor = Color.Black;

            if (_activeEntry is not null && _activeEntry.Entry.Type == PlaylistEntryType.Song) songTimer.Start();
        }

        private void btnTimeStore_Click(object sender, EventArgs e)
        {
            if (_activeEntry is null || _activeEntry.Entry.Type != PlaylistEntryType.Song) return;
            var songEntry = (SongPlaylistEntry)_activeEntry.Entry;
            var song = _database.Songs[songEntry.SongId];
            song.ExpectedDurationSeconds = _secondsCounter;
            songTime.Text = $"{TimeSpan.FromSeconds(_secondsCounter):mm\\:ss} (+00:00)";
            songTime.ForeColor = Color.Black;
        }

        private record PlaylistListBoxItem(PlaylistEntryCommonInfo Info, IPlaylistEntry Entry)
        {
            public override string ToString() => Info.Header;
        }

        private record SetsListBoxItem(Playlist? playlist)
        {
            public override string ToString() => playlist is null ? "[BACKLOG]" : $"{playlist.Name} ({playlist.Date})";
        }

        private record CueListBoxItem(int Index, CueInstance Cue, string CueName)
        {
            public override string ToString() => $"{Index + 1}. {Cue.Description}({CueName})";
        }
    }
}
