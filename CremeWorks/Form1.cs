﻿using System;
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

        public Form1()
        {
            InitializeComponent();
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e) => new MIDISetUp(_c).ShowDialog();
        private void footSwitchToolStripMenuItem_Click(object sender, EventArgs e) => new FootSwitchConfig(_c).ShowDialog();

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_c == null) return;
            if (connectToolStripMenuItem.Text == "Connect") _c.Connect(); else _c.Disconnect();
        }

        private void Form1_Load(object sender, EventArgs e) =>_c.ConnectionChangeHandler = (x) => connectToolStripMenuItem.Text = x ? "Disconnect" : "Connect";

        private void UpdatePlaylist()
        {
            playList.Items.Clear();
            foreach (var element in _c.Playlist)
                playList.Items.Add(element.Title + " - " + element.Artist);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
