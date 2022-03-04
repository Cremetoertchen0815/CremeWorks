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
    public partial class LightingPreset : Form
    {

        private LightController _c;
        public LightingPreset(LightController c)
        {
            InitializeComponent();
            _c = c;
        }

        private void button1_Click(object sender, EventArgs e) => Close();

        private void button2_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    ClearData();
                    for (int i = 0; i < 16; i++)
                    {
                        _c.Names[i] = "Scene " + (i + 1);
                        _c.Names[16 + i] = "Chaser " + (i + 1);
                        _c.ResetWhenSongChange[i] = true;
                        _c.ResetWhenSongChange[16 + i] = true;
                        _c.ToggleGroups[16 + i] = 1;
                        _c.IsToggleable[i] = true;
                        _c.IsToggleable[16 + i] = true;
                    }
                    _c.Names[32] = "Manual";
                    _c.Names[33] = "Music";
                    _c.Names[34] = "Auto";
                    _c.Names[35] = "Aux 1";
                    _c.Names[36] = "Aux 2";
                    _c.Names[37] = "Previous Step";
                    _c.Names[38] = "Next Step";
                    _c.Names[39] = "Tap";
                    _c.Names[126] = "Tap";
                    _c.IsToggleable[35] = true;
                    _c.IsToggleable[36] = true;
                    _c.IsToggleable[126] = true;
                    break;
                case 1:
                    ClearData();
                    break;
                default:
                    break;
            }

            Close();
        }

        private void ClearData()
        {
            for (int i = 0; i < _c.Names.Length; i++) _c.Names[i] = null;
            for (int i = 0; i < _c.ToggleGroups.Length; i++) _c.ToggleGroups[i] = 0;
            for (int i = 0; i < _c.ResetWhenSongChange.Length; i++) _c.ResetWhenSongChange[i] = false;
            for (int i = 0; i < _c.IsToggleable.Length; i++) _c.IsToggleable[i] = false;
        }
    }
}
