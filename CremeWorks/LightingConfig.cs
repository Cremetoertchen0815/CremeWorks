using System;
using System.Windows.Forms;

namespace CremeWorks
{
    public partial class LightingConfig : Form
    {

        private readonly LightController _c;
        public LightingConfig(Concert c)
        {
            InitializeComponent();
            _c = c.LightConfig;
            numericUpDown1_ValueChanged(null, null);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int nr = (int)numericUpDown1.Value;
            textBox1.Text = _c.Names[nr] ?? "";
            comboBox1.SelectedIndex = _c.ToggleGroups[nr];
            checkBox1.Checked = _c.ResetWhenSongChange[nr];
        }

        private void textBox1_TextChanged(object sender, EventArgs e) => _c.Names[(int)numericUpDown1.Value] = textBox1.Text == string.Empty ? null : textBox1.Text;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) => _c.ToggleGroups[(int)numericUpDown1.Value] = comboBox1.SelectedIndex;
        private void checkBox1_CheckedChanged(object sender, EventArgs e) => _c.ResetWhenSongChange[(int)numericUpDown1.Value] = checkBox1.Checked;
    }
}
