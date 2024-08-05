using CremeWorks.App;
using CremeWorks.App.Data;
using CremeWorks.Common;
using CremeWorks.Networking;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CremeWorks
{
    public partial class MainForm : Form, IDataParent
    {
        private Database _database;
        private IPlaylistEntry? _activeEntry = null;
        private NetworkingServer _server;
        private readonly MidiEventToBytesConverter _converter = new();
        private readonly Metronome _metronome = new Metronome();
        private bool _sendMetronomeData = false;
        private int _playlistDragIndex = -1;
        private bool _wasPlaylistOrderChanged = false;

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

            _server = new NetworkingServer();
            _server.UserJoined += _server_UserJoined;
            _server.MessageReceived += _server_MessageReceived;

            _metronome.Tick += TickMetronome;

            UpdateConcert();
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e) => new MIDISetUp(_c).ShowDialog();
        private void footSwitchToolStripMenuItem_Click(object sender, EventArgs e) => new FootSwitchConfig(_c).ShowDialog();

        private void startMIDIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_c == null) return;
            if (!startMIDIToolStripMenuItem.Checked)
            {
                _c.Connect();
                _c.MidiMatrix.Register();
                startMIDIToolStripMenuItem.Checked = true;
            }
            else
            {
                _c.Disconnect();
                startMIDIToolStripMenuItem.Checked = false;
            }
        }

        private void UpdatePlaylist()
        {
            playList.Items.Clear();
            int idx = 1;
            foreach (var element in _c.Playlist)
            {
                string text = element.SpecialEvent ? $"---{element.Title}---" : $"{idx++.ToString("D2")}.{element.Title} - {element.Artist}";
                playList.Items.Add(text);
            }

            _server.SendToAll(MessageTypeEnum.SET_DATA, GetClientSet());
        }

        private readonly string[] Buchstaben = { "A", "B", "C", "D", "E", "F" };

        private void UpdateSong()
        {
            songTitle.Text = string.Empty;
            songLyrics.Text = string.Empty;
            songKey.Text = "";
            songTempo.Text = "";
            lightCue.Items.Clear();
            _server.SendToAll(MessageTypeEnum.CURRENT_SONG, GetCurrentSongInformation());

            if (_s == null)
            {
                _server.SendToAll(MessageTypeEnum.CLICK_INFO, "off");
                _metronome.Stop();
                return;
            }

            for (int i = 0; i < _s.CueQueue.Count; i++)
            {
                var cueType = _c.LightingCues.FirstOrDefault(x => x.ID == _s.CueQueue[i].ID).Name;
                lightCue.Items.Add($"{i + 1}. {_s.CueQueue[i].comment}({cueType})");
            }
            //Configure shit
            songTitle.Text = _s.Title;
            songLyrics.Text = _s.Lyrics;
            songKey.Text = _s.Key;
            songTempo.Text = _s.Tempo.ToString() + " BPM";
            _metronome.Start(_s.Tempo);
            _sendMetronomeData = true;
            ConfigSongMIDI();

            //Load default cue patch
            if (lightCue.Items.Count > 0) lightCue.SelectedIndex = 0;
        }

        private void ConfigSongMIDI()
        {
            _c.MidiMatrix.ActiveSong = _s;

            for (int i = 0; i < Concert.PATCH_DEVICE_COUNT; i++) if (_s.AutoPatchSlots[i].Enabled) _s.AutoPatchSlots[i].Patch?.ApplyPatch(_c.MIDIDevices[MIDIMatrix.INSTR_DEVICE_OFFSET + i]);
        }

        private void ExecuteAction(int nr, bool? enable)
        {
            bool chk = enable ?? true;
            switch (nr)
            {
                case 0:
                    if (chk && playList.SelectedIndex > 0) playList.SelectedIndex--;
                    break;
                case 1:
                    if (chk && playList.SelectedIndex < playList.Items.Count - 1) playList.SelectedIndex++;
                    break;
                case 2:
                    if (!chk) break;
                    SetScrollPos(songLyrics.Handle, 1, -10, true);
                    SendMessage(songLyrics.Handle, EM_LINESCROLL, 0, -10);
                    break;
                case 3:
                    if (!chk) break;
                    SetScrollPos(songLyrics.Handle, 1, 10, true);
                    SendMessage(songLyrics.Handle, EM_LINESCROLL, 0, 10);
                    break;
                case 4:
                    if (lightCue.SelectedIndex > 0) lightCue.SelectedIndex--;
                    break;
                case 5:
                    if (lightCue.SelectedIndex < lightCue.Items.Count - 1) lightCue.SelectedIndex++;
                    break;
            }
        }

        private void playList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _s = playList.SelectedIndex >= 0 ? _c.Playlist[playList.SelectedIndex] : null;
            UpdateSong();
        }

        private void New(object sender, EventArgs e)
        {
            _c = Concert.Empty(SendLighingData);
            UpdateConcert();
        }

        private void UpdateConcert()
        {
            string tit = (_c?.FilePath == string.Empty ? null : _c?.FilePath) ?? "Untitled";
            string titClean = (_c?.FilePath == string.Empty ? null : Path.GetFileNameWithoutExtension(_c?.FilePath)) ?? "Untitled";
            Text = "CremeWorks Stage Controller - " + tit;
            _server.SendToAll(MessageTypeEnum.CONCERT_NAME, titClean);
            if (_c is null)
            {
                playList.Items.Clear();
                _server.SendToAll(MessageTypeEnum.SET_DATA, "[]");
                return;
            }

            _c.MidiMatrix.ActionExecute = ExecuteAction;
            _c.ConnectionChangeHandler = x => startMIDIToolStripMenuItem.Checked = x;

            UpdatePlaylist();
            playList.SelectedIndex = -1;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            _c = Concert.LoadFromFile(openFileDialog1.FileName, SendLighingData);
            if (_c is null) MessageBox.Show("Concert file is corrupted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            UpdateConcert();
        }

        private void Save(object sender, EventArgs e)
        {
            if (_c == null) return;
            if (_c.FilePath == null || _c.FilePath == string.Empty)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) _c.SaveToFile(saveFileDialog1.FileName);
            }
            else
            {
                _c.SaveToFile(_c.FilePath);
            }
            UpdateConcert();
        }

        private void SaveAs(object sender, EventArgs e)
        {
            if (_c == null || saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            _c.SaveToFile(saveFileDialog1.FileName);
            UpdateConcert();
        }

        private void lightControllerToolStripMenuItem_Click(object sender, EventArgs e) => new LightCueManager(_c, SendLightNoteOnOff).ShowDialog();

        private async void lightCue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_s != null && lightCue.SelectedIndex >= 0)
            {
                _server.SendToAll(MessageTypeEnum.CUE_INDEX, lightCue.SelectedIndex.ToString());

                //Send light cue
                var noteOnVal = _c.LightingCues.FirstOrDefault(x => x.ID == _s.CueQueue[lightCue.SelectedIndex].ID)?.NoteValue;
                if (noteOnVal is null) return;
                SendLighingData(new NoteOnEvent(new SevenBitNumber(noteOnVal.Value), SevenBitNumber.MaxValue) { Channel = new FourBitNumber(1) });
                await Task.Delay(50);
                SendLighingData(new NoteOnEvent(new SevenBitNumber(noteOnVal.Value), SevenBitNumber.MinValue) { Channel = new FourBitNumber(1) });
            }
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
            string tit = (_c?.FilePath == string.Empty ? null : Path.GetFileNameWithoutExtension(_c?.FilePath)) ?? "Untitled";
            con.SendMessage(MessageTypeEnum.CONCERT_NAME, tit);
            con.SendMessage(MessageTypeEnum.SET_DATA, GetClientSet());
            con.SendMessage(MessageTypeEnum.CURRENT_SONG, GetCurrentSongInformation());
            con.SendMessage(MessageTypeEnum.CUE_INDEX, lightCue.SelectedIndex.ToString());
        }
        private string[] GetClientSet()
        {
            int idx = 1;
            return _c.Playlist.Select(x => x.SpecialEvent ? $"---{x.Title}---" : $"{idx++:D2}.{x.Title} - {x.Artist}").ToArray();
        }

        private SongInformation GetCurrentSongInformation()
        {
            if (_s is null) return new SongInformation()
            {
                Index = -1,
                SmallName = "-",
                ClickActive = false,
                Tempo = 120,
                Cues = new string[] { },
                Instructions = string.Empty
            };


            return new SongInformation()
            {
                Index = playList.SelectedIndex,
                SmallName = _s.Title,
                ClickActive = _s.Click,
                Tempo = _s.Tempo,
                Cues = _s.CueQueue.Select(x => x.comment).ToArray(),
                Instructions = _s.Instructions
            };
        }

        private void SendLighingData(MidiEvent e)
        {
            var bytes = _converter.Convert(e);
            _server.SendToAll(MessageTypeEnum.LIGHT_MESSAGE, Convert.ToBase64String(bytes));
        }

        private void SendLightNoteOnOff(byte noteVal) => Task.Run(async () =>
        {
            SendLighingData(new NoteOnEvent(new SevenBitNumber(noteVal), SevenBitNumber.MaxValue) { Channel = new FourBitNumber(1) });
            await Task.Delay(50);
            SendLighingData(new NoteOnEvent(new SevenBitNumber(noteVal), SevenBitNumber.MinValue) { Channel = new FourBitNumber(1) });
        });

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
                _server.SendToAll(MessageTypeEnum.CLICK_INFO, !_s.Click ? "off" : _s.Tempo.ToString());
                _sendMetronomeData = false;
            }
            await Task.Delay(15);
            boxTempo.BackColor = System.Drawing.Color.Navy;
            await Task.Delay(50);
            boxTempo.BackColor = System.Drawing.Color.White;
        }

        private void exportSetToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_c is null || csvExportSaveFile.ShowDialog() != DialogResult.OK) return;
            File.WriteAllText(csvExportSaveFile.FileName, _c.ToCsv());
        }

        private bool _chatboxLit = false;

        public Database Database => throw new NotImplementedException();

        private async void LightUpChatbox()
        {
            if (_chatboxLit) return;
            _chatboxLit = true;
            var original = chatBox.BackColor;
            chatBox.BackColor = System.Drawing.Color.Lime;
            await Task.Delay(500);
            chatBox.BackColor = original;
            _chatboxLit = false;

        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e) => Close();
    }
}
