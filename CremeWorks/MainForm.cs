using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CremeWorks
{
    public partial class MainForm : Form
    {
        private Concert _c = Concert.Empty();
        private Song _s = null;

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
            UpdateConcert();
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e) => new MIDISetUp(_c).ShowDialog();
        private void footSwitchToolStripMenuItem_Click(object sender, EventArgs e) => new FootSwitchConfig(_c).ShowDialog();

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_c == null) return;
            if (connectToolStripMenuItem.Text == "Connect")
            {
                _c.Connect();
                _c.MidiMatrix.Register();
            }
            else
            {
                _c.Disconnect();
            }
        }

        private void UpdatePlaylist()
        {
            playList.Items.Clear();
            foreach (Song element in _c.Playlist)
                playList.Items.Add(element.Title + " - " + element.Artist);

        }

        private string[] Buchstaben = { "A", "B", "C", "D", "E", "F", "G", "H" };

        private void UpdateSong()
        {
            songTitle.Text = string.Empty;
            songLyrics.Text = string.Empty;
            txtKey.Text = string.Empty;

            button5.Text = (_s?.QA[0] ?? -1) < 0 ? "Quick Access " + Buchstaben[0] : _c.LightConfig.Names[_s.QA[0]];
            button7.Text = (_s?.QA[1] ?? -1) < 0 ? "Quick Access " + Buchstaben[1] : _c.LightConfig.Names[_s.QA[1]];
            button6.Text = (_s?.QA[2] ?? -1) < 0 ? "Quick Access " + Buchstaben[2] : _c.LightConfig.Names[_s.QA[2]];
            button9.Text = (_s?.QA[3] ?? -1) < 0 ? "Quick Access " + Buchstaben[3] : _c.LightConfig.Names[_s.QA[3]];
            button8.Text = (_s?.QA[4] ?? -1) < 0 ? "Quick Access " + Buchstaben[4] : _c.LightConfig.Names[_s.QA[4]];
            button11.Text = (_s?.QA[5] ?? -1) < 0 ? "Quick Access " + Buchstaben[5] : _c.LightConfig.Names[_s.QA[5]];
            button10.Text = (_s?.QA[6] ?? -1) < 0 ? "Quick Access " + Buchstaben[6] : _c.LightConfig.Names[_s.QA[6]];

            if (_s == null) return;

            //Configure shit
            songTitle.Text = _s.Title;
            songLyrics.Text = _s.Lyrics;
            txtKey.Text = "Key: " + _s.Key;
            ConfigSongMIDI();

            //Load default QA patch
            ExecuteAction(12, null);
        }

        private void ConfigSongMIDI()
        {
            _c.MidiMatrix.NoteMap = _s.NotePatchMap;
            _c.MidiMatrix.CCMap = _s.CCPatchMap;

            for (var i = 0; i < 4; i++) if (_s.AutoPatchSlots[i].Enabled) _s.AutoPatchSlots[i].Patch?.ApplyPatch(_c.Devices[i + 2]);
        }

        private void ExecuteAction(int nr, bool? enable)
        {
            var chk = enable ?? true;
            switch (nr)
            {
                case 0:
                    if (chk && playList.SelectedIndex > 0) playList.SelectedIndex--;
                    break;
                case 1:
                    if (chk && playList.SelectedIndex < playList.Items.Count - 1) playList.SelectedIndex++;
                    break;
                case 2:
                    if (chk) foreach (MIDIDevice item in _c.Devices) if (item.Output != null) item.Output.TurnAllNotesOff();
                    break;
                case 3:
                    if (!chk) break;
                    SetScrollPos(songLyrics.Handle, 1, -10, true);
                    SendMessage(songLyrics.Handle, EM_LINESCROLL, 0, -10);
                    break;
                case 4:
                    if (!chk) break;
                    SetScrollPos(songLyrics.Handle, 1, 10, true);
                    SendMessage(songLyrics.Handle, EM_LINESCROLL, 0, 10);
                    break;
                case 12:
                    _c.LightConfig.SetState(_s.QA[7], true);
                    break;
                default:
                    _c.LightConfig.SetState(_s.QA[nr - 5], enable);
                    break;
            }
        }

        private void AddNewSong(object sender, EventArgs e)
        {
            if (_c == null) return;
            var ns = new Song();
            if (new SongEditor(_c, ns).ShowDialog() != DialogResult.OK) return;
            _c.Playlist.Add(ns);
            UpdatePlaylist();
        }

        private void EditSong(object sender, EventArgs e)
        {
            if (_c == null || playList.SelectedIndex < 0) return;
            new SongEditor(_c, _c.Playlist[playList.SelectedIndex]).ShowDialog();
            UpdatePlaylist();
        }

        private void playList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _s = playList.SelectedIndex >= 0 ? _c.Playlist[playList.SelectedIndex] : null;
            UpdateSong();
        }

        private void ShortcutButtonDown(object sender, MouseEventArgs e) => ExecuteAction(int.Parse((string)((Button)sender).Tag) + 2, qAButtonToggleToolStripMenuItem.Checked ? null : (bool?)true);
        private void ShortcutButtonUp(object sender, MouseEventArgs e) { if(!qAButtonToggleToolStripMenuItem.Checked) ExecuteAction(int.Parse((string)((Button)sender).Tag) + 2, false); }

        private void RemSong(object sender, EventArgs e)
        {
            if (playList.SelectedIndex >= 0) _c.Playlist.RemoveAt(playList.SelectedIndex);
            UpdatePlaylist();
        }

        private void applySongSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_c == null || _s == null) return;
            for (var i = 0; i < 4; i++) if (_s.AutoPatchSlots[i].Enabled) _s.AutoPatchSlots[i].Patch?.ApplySettings(_c.Devices[i + 2]);
        }

        private int nIndex = -1;
        private void playList_MouseDown(object sender, MouseEventArgs e) => nIndex = playList.SelectedIndex;
        private void playList_MouseUp(object sender, MouseEventArgs e) => nIndex = -1;
        private void playList_MouseMove(object sender, MouseEventArgs e)
        {
            var sIndex = playList.SelectedIndex;
            if (e.Button == MouseButtons.Left && nIndex > -1 && nIndex != sIndex)
            {
                var aObj = playList.Items[nIndex];
                Song bObj = _c.Playlist[nIndex];

                playList.Items[nIndex] = playList.Items[sIndex];
                _c.Playlist[nIndex] = _c.Playlist[sIndex];


                playList.Items[sIndex] = aObj;
                _c.Playlist[sIndex] = bObj;

                nIndex = sIndex;
            }
        }

        private void DuplicateSong(object sender, EventArgs e)
        {
            if (playList.SelectedIndex < 0) return;
            Song cpy = _c.Playlist[playList.SelectedIndex].Clone();
            _c.Playlist.Add(cpy);
            UpdatePlaylist();
        }

        private void New(object sender, EventArgs e)
        {
            _c = Concert.Empty();
            UpdateConcert();
        }

        private void UpdateConcert()
        {
            var tit = _c?.FilePath ?? "Untitled";
            Text = "CremeWorks Stage Controller - " + (tit == string.Empty ? "Untitled" : tit);
            _c.MidiMatrix.ActionExecute = ExecuteAction;
            _c.ConnectionChangeHandler = (x) => connectToolStripMenuItem.Text = x ? "Disconnect" : "Connect";
            UpdatePlaylist();
            playList.SelectedIndex = -1;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            _c = Concert.LoadFromFile(openFileDialog1.FileName);
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

        private void lightControllerToolStripMenuItem_Click(object sender, EventArgs e) => new LightingConfig(_c).ShowDialog();

        private void qAButtonToggleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qAButtonToggleToolStripMenuItem.Checked = !qAButtonToggleToolStripMenuItem.Checked;
        }
    }
}
