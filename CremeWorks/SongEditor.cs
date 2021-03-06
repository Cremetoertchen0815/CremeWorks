using System;
using System.Windows.Forms;

namespace CremeWorks
{
    public partial class SongEditor : Form
    {
        private readonly Concert _c;
        private readonly Song _s;
        private readonly CheckBox[][] _mapMatrixA;
        private readonly CheckBox[][] _mapMatrixB;
        private readonly Button[] _mapQA;

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

            _mapQA = new Button[] { button12, button5, button11, button6, button10 };

            //Load data
            txtTitle.Text = s.Title;
            txtArtist.Text = s.Artist;
            txtKey.Text = s.Key;
            txtLyrics.Text = s.Lyrics;
            apM.Checked = apbM.Enabled = s.AutoPatchSlots[0].Enabled;
            ap1.Checked = apb1.Enabled = s.AutoPatchSlots[1].Enabled;
            ap2.Checked = apb2.Enabled = s.AutoPatchSlots[2].Enabled;
            ap3.Checked = apb3.Enabled = s.AutoPatchSlots[3].Enabled;
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    _mapMatrixA[x][y].Checked = s.NotePatchMap[x][y];
                    _mapMatrixB[x][y].Checked = s.CCPatchMap[x][y];
                }
            }

            for (int i = 0; i < _mapQA.Length; i++)
            {
                sbyte val = _s.QA[i];
                if (i < 5) _mapQA[i].Text = val < 0 ? "Quick Access " + Buchstaben[i] : _c.LightConfig.Names[val];
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
            _s.Key = txtKey.Text;
            _s.Lyrics = txtLyrics.Text;
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    _s.NotePatchMap[x][y] = _mapMatrixA[x][y].Checked;
                    _s.CCPatchMap[x][y] = _mapMatrixB[x][y].Checked;
                }
            }
        }

        private void SysExEdit(object sender, EventArgs e) => new APEditor(_c, _s, int.Parse((string)((Button)sender).Tag)).ShowDialog();

        private void apM_Click(object sender, EventArgs e)
        {
            //Update controls
            var chk = ((CheckBox)sender);
            int id = int.Parse((string)chk.Tag);
            switch (id)
            {
                case 0:
                    apbM.Enabled = chk.Checked;
                    break;
                case 1:
                    apb1.Enabled = chk.Checked;
                    break;
                case 2:
                    apb2.Enabled = chk.Checked;
                    break;
                case 3:
                    apb3.Enabled = chk.Checked;
                    break;
                default:
                    break;
            }

            //Update database
            var patchBuffer = _s.AutoPatchSlots[id].Patch;
            _s.AutoPatchSlots[id] = (chk.Checked, patchBuffer);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            var src = (Button)sender;
            int nr = int.Parse((string)src.Tag);
            new QASelector(_c, _s, nr).ShowDialog();
            sbyte val = _s.QA[nr];
            if (nr < 5) src.Text = val < 0 ? "Quick Access " + Buchstaben[nr] : _c.LightConfig.Names[val];
        }

        private readonly string[] Buchstaben = { "A", "B", "C", "D", "E" };
    }
}
