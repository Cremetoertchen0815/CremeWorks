using CremeWorks.App;
using CremeWorks.App.Data;
using CremeWorks.App.Dialogs;
using CremeWorks.App.Properties;
using CremeWorks.Common;
using CremeWorks.Networking;
using Melanchall.DryWetMidi.Core;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

namespace CremeWorks
{
    public partial class MainForm : Form, IDataParent
    {
        private Database _database;
        private MidiManager _midiManager;
        private IPlaylistEntry? _activeEntry = null;
        private NetworkingServer _server;
        private readonly MidiEventToBytesConverter _converter = new();
        private readonly Metronome _metronome;
        private bool _sendMetronomeData = false;

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

            _server = new NetworkingServer();
            _server.UserJoined += _server_UserJoined;
            _server.MessageReceived += _server_MessageReceived;

            _metronome = new Metronome();
            _metronome.Tick += TickMetronome;

            syncToolStripMenuItem.Checked = Settings.Default.SyncToCloud;
            if (Settings.Default.Recents == null)
            {
                Settings.Default.Recents = new();
                Settings.Default.Save();
            }
            foreach (var item in Settings.Default.Recents) openRecentToolStripMenuItem.DropDownItems.Add(new ToolStripMenuItem(item));

            UpdateConcert();
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e) => new MidiSetUp(this).ShowDialog();
        private void footSwitchToolStripMenuItem_Click(object sender, EventArgs e) => new FootSwitchConfig(this).ShowDialog();

        private void startMIDIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!startMIDIToolStripMenuItem.Checked)
            {
                _midiManager.Connect();
            }
            else
            {
                _midiManager.Disconnect();
            }

            startMIDIToolStripMenuItem.Checked = !startMIDIToolStripMenuItem.Checked;
        }

        private void UpdatePlaylist()
        {
            playList.Items.Clear();
            var sortedSongEntries = Enumerable.Empty<IPlaylistEntry>();
            if (boxSet.SelectedIndex > 0)
            {
                var playlist = _database.Playlists[boxSet.SelectedIndex - 1];
                sortedSongEntries = playlist.Elements;
            }
            else
            {
                sortedSongEntries = _database.Songs.OrderBy(x => x.Value.Artist).ThenBy(x => x.Value.Title).Select(x => new SongPlaylistEntry(x.Key));
            }

            playList.Items.AddRange(sortedSongEntries.Select(x => new SetListBoxItem(x.GetCommonInformation(_database).Header, x)).ToArray());
            //_server.SendToAll(MessageTypeEnum.SET_DATA, GetClientSet());
            _activeEntry = null;
            UpdateSong();
        }

        private readonly string[] Buchstaben = { "A", "B", "C", "D", "E", "F" };

        private void UpdateSong()
        {
            songTitle.Text = string.Empty;
            songLyrics.Text = string.Empty;
            songKey.Text = "";
            songTempo.Text = "";
            lightCue.Items.Clear();
            //_server.SendToAll(MessageTypeEnum.CURRENT_SONG, GetCurrentSongInformation());

            if (_activeEntry == null)
            {
                _server.SendToAll(MessageTypeEnum.CLICK_INFO, "off");
                _metronome.Stop();
                return;
            }

            var information = _activeEntry.GetCommonInformation(_database);
            songTitle.Text = information.Title;
            songLyrics.Text = information.Lyrics;
            songKey.Text = information.Key;
            songTempo.Text = information.Tempo.ToString() + " BPM";
            _metronome.Start(information.Tempo);
            lightCue.Items.AddRange(information.Cues.Select((x, i) => new CueListBoxItem(i, x, _database.LightingCues[x.CueId].Name)).ToArray());

            //Configure shit
            _sendMetronomeData = true;
            _midiManager.UpdateMatrix();

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
            _activeEntry = playList.SelectedIndex >= 0 ? (playList.SelectedItem as SetListBoxItem)?.Entry : null;
            UpdateSong();
        }

        private void New(object sender, EventArgs e)
        {
            _database = new Database();
            UpdateConcert();
        }

        private void UpdateConcert()
        {
            string tit = _database.FilePath is null or "" ? "Untitled" : _database.FilePath;
            string titClean = _database.FilePath is null or "" ? "Untitled" : Path.GetFileNameWithoutExtension(_database.FilePath);
            Text = "CremeWorks Stage Controller - " + tit;
            _server.SendToAll(MessageTypeEnum.CONCERT_NAME, titClean);
            if (_database is null)
            {
                playList.Items.Clear();
                _server.SendToAll(MessageTypeEnum.SET_DATA, "[]");
                return;
            }

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
                    openRecentToolStripMenuItem.DropDownItems.Add(new ToolStripMenuItem(openFileDialog1.FileName));
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

            UpdateConcert();
        }

        private void SaveAs(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            _database.FilePath = saveFileDialog1.FileName;
            FileParser.SaveFile(_database.FilePath, _database);
            UpdateConcert();
        }

        private void lightControllerToolStripMenuItem_Click(object sender, EventArgs e) => new LightCueManager(this).ShowDialog();

        private void playlistsToolStripMenuItem_Click(object sender, EventArgs e) => new PlaylistEditor(this).ShowDialog();

        private void lightCue_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (_s != null && lightCue.SelectedIndex >= 0)
            //{
            //    _server.SendToAll(MessageTypeEnum.CUE_INDEX, lightCue.SelectedIndex.ToString());

            //    //Send light cue
            //    var noteOnVal = _c.LightingCues.FirstOrDefault(x => x.ID == _s.CueQueue[lightCue.SelectedIndex].ID)?.NoteValue;
            //    if (noteOnVal is null) return;
            //    SendLighingData(new NoteOnEvent(new SevenBitNumber(noteOnVal.Value), SevenBitNumber.MaxValue) { Channel = new FourBitNumber(1) });
            //    await Task.Delay(50);
            //    SendLighingData(new NoteOnEvent(new SevenBitNumber(noteOnVal.Value), SevenBitNumber.MinValue) { Channel = new FourBitNumber(1) });
            //}
        }

        private void btnChatSend_Click(object sender, EventArgs e)
        {
            var msg = "Server: " + chatInput.Text;
            chatBox.Items.Add(msg);
            _server.SendToAll(MessageTypeEnum.CHAT_MESSAGE, msg);
            chatInput.Text = string.Empty;
            chatBox.SelectedIndex = chatBox.Items.Count - 1;
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
            //string tit = (_c?.FilePath == string.Empty ? null : Path.GetFileNameWithoutExtension(_c?.FilePath)) ?? "Untitled";
            //con.SendMessage(MessageTypeEnum.CONCERT_NAME, tit);
            //con.SendMessage(MessageTypeEnum.SET_DATA, GetClientSet());
            //con.SendMessage(MessageTypeEnum.CURRENT_SONG, GetCurrentSongInformation());
            //con.SendMessage(MessageTypeEnum.CUE_INDEX, lightCue.SelectedIndex.ToString());
        }
        //private string[] GetClientSet()
        //{
        //    int idx = 1;
        //    return _c.Playlist.Select(x => x.SpecialEvent ? $"---{x.Title}---" : $"{idx++:D2}.{x.Title} - {x.Artist}").ToArray();
        //}

        //private void SendLighingData(MidiEvent e)
        //{
        //    var bytes = _converter.Convert(e);
        //    _server.SendToAll(MessageTypeEnum.LIGHT_MESSAGE, Convert.ToBase64String(bytes));
        //}

        //private void SendLightNoteOnOff(byte noteVal) => Task.Run(async () =>
        //{
        //    SendLighingData(new NoteOnEvent(new SevenBitNumber(noteVal), SevenBitNumber.MaxValue) { Channel = new FourBitNumber(1) });
        //    await Task.Delay(50);
        //    SendLighingData(new NoteOnEvent(new SevenBitNumber(noteVal), SevenBitNumber.MinValue) { Channel = new FourBitNumber(1) });
        //});

        private void _server_MessageReceived(MessageTypeEnum type, string data, NetworkConnection con) => Invoke(new Action(() =>
        {
            switch (type)
            {
                case MessageTypeEnum.CHAT_MESSAGE:
                    var msg = $"{con.Name}: {data}";
                    chatBox.Items.Add(msg);
                    _server.SendToAll(MessageTypeEnum.CHAT_MESSAGE, msg);
                    chatBox.SelectedIndex = chatBox.Items.Count - 1;
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
                //_server.SendToAll(MessageTypeEnum.CLICK_INFO, !_s.Click ? "off" : _s.Tempo.ToString());
                _sendMetronomeData = false;
            }
            await Task.Delay(15);
            boxTempo.BackColor = System.Drawing.Color.Navy;
            await Task.Delay(50);
            boxTempo.BackColor = System.Drawing.Color.White;
        }

        private void exportSetToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (_c is null || csvExportSaveFile.ShowDialog() != DialogResult.OK) return;
            //File.WriteAllText(csvExportSaveFile.FileName, _c.ToCsv());
        }

        private bool _chatboxLit = false;

        public Database Database => _database;
        public MidiManager MidiManager => _midiManager;

        public IPlaylistEntry? CurrentEntry => _activeEntry;

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

        private void boxSet_SelectedIndexChanged(object sender, EventArgs e) => UpdateConcert();

        private void patchesToolStripMenuItem_Click(object sender, EventArgs e) => new PatchEditor(this).ShowDialog();

        private void syncToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            Settings.Default.SyncToCloud = syncToolStripMenuItem.Checked;
            Settings.Default.Save();
        }

        private record SetListBoxItem(string Name, IPlaylistEntry Entry)
        {
            public override string ToString() => Name;
        }

        private record CueListBoxItem(int Index, CueInstance cue, string cueName)
        {
            public override string ToString() => $"{Index + 1}. {cue.Description}({cueName})";
        }
    }
}
