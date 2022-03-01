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
    public partial class SongEditor : Form
    {
        private Concert _c;
        private Song _s;
        private CheckBox[][] _mapMatrixA;
        private CheckBox[][] _mapMatrixB;

        public SongEditor(Concert c, Song s)
        {
            InitializeComponent();
            _c = c;
            _s = s;
            DialogResult = DialogResult.Cancel;
            _c.MidiMatrix.Unregister();

            //Map matrix
            _mapMatrixA = new CheckBox[][] { new CheckBox[] {chkMM, chkM1, chkM2, chkM3 }, new CheckBox[] { chk1M, chk11, chk12, chk13 },
                                            new CheckBox[] { chk2M, chk21, chk22, chk23 }, new CheckBox[] { chk3M, chk31, chk32, chk33 } };
            _mapMatrixB = new CheckBox[][] { new CheckBox[] {ccMM, ccM1, ccM2, ccM3 }, new CheckBox[] { cc1M, cc11, cc12, cc13 },
                                            new CheckBox[] { cc2M, cc21, cc22, cc23 }, new CheckBox[] { cc3M, cc31, cc32, cc33 } };

            //Load data
            txtTitle.Text = s.Title;
            txtArtist.Text = s.Artist;
            txtNotes.Text = s.Notes;
            txtLyrics.Text = s.Lyrics;
            for (int x = 0; x < 4; x++)
                for (int y = 0; y < 4; y++)
                {
                    _mapMatrixA[x][y].Checked = s.NoteMap[x][y];
                    _mapMatrixB[x][y].Checked = s.CCMap[x][y];
                }
        }

        private void CloseOK(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CloseCancel(object sender, EventArgs e) => Close();

        private void SongEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            _c.MidiMatrix.Register();
            if (DialogResult != DialogResult.OK) return; //Don't save changes if aborting

            //Save changes
            _s.Title = txtTitle.Text;
            _s.Artist = txtArtist.Text;
            _s.Notes = txtNotes.Text;
            _s.Lyrics = txtLyrics.Text;
            for (int x = 0; x < 4; x++)
                for (int y = 0; y < 4; y++)
                {
                    _s.NoteMap[x][y] = _mapMatrixA[x][y].Checked;
                    _s.CCMap[x][y] = _mapMatrixB[x][y].Checked;
                }
        }

        private void SysExEdit(object sender, EventArgs e) => new ACEditor(_c, _c.Devices[2 + int.Parse((string)((Button)sender).Tag)]).ShowDialog();
    }
}
