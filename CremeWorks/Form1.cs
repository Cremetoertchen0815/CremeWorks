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
    public partial class Form1 : Form
    {
        private Concert _c = Concert.Empty();
        private Song _s = null;

        public Form1()
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
    }
}
