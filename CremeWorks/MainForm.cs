using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CremeWorks
{
    public partial class MainForm : Form
    {
        private Concert _c = Concert.Empty();
        private Song _s = null;

        public MainForm()
        {
            InitializeComponent();
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
                _c.MidiMatrix.ActionExecute = ExecuteAction;
            }
            else
                _c.Disconnect();
        }

        private void Form1_Load(object sender, EventArgs e) =>_c.ConnectionChangeHandler = (x) => connectToolStripMenuItem.Text = x ? "Disconnect" : "Connect";

        private void UpdatePlaylist()
        {
            playList.Items.Clear();
            foreach (var element in _c.Playlist)
                playList.Items.Add(element.Title + " - " + element.Artist);
        }

        private void UpdateSong()
        {
            songTitle.Text = string.Empty;
            songLyrics.Text = string.Empty;
            if (_s == null) return;


            songTitle.Text = _s.Title;
            songLyrics.Text = _s.Lyrics;
            ConfigSongMIDI();
        }

        private void ConfigSongMIDI()
        {
            _c.MidiMatrix.NoteMap = _s.NoteMap;
            _c.MidiMatrix.CCMap = _s.CCMap;
        }

        private void ExecuteAction(int nr, bool enable)
        {
            switch (nr)
            {
                case 0:
                    if (enable && playList.SelectedIndex > 0) playList.SelectedIndex--;
                    break;
                case 1:
                    if (enable && playList.SelectedIndex < playList.Items.Count - 1) playList.SelectedIndex++;
                    break;
                default:
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

        private void ShortcutButtonDown(object sender, MouseEventArgs e) => ExecuteAction(int.Parse((string)((Button)sender).Tag) + 2, true);
        private void ShortcutButtonUp(object sender, MouseEventArgs e) => ExecuteAction(int.Parse((string)((Button)sender).Tag) + 2, false);

        private void RemSong(object sender, EventArgs e)
        {
            if (playList.SelectedIndex >= 0) _c.Playlist.RemoveAt(playList.SelectedIndex);
            UpdatePlaylist();
        }
    }
}
