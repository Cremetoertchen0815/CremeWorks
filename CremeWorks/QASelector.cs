using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CremeWorks
{
    public partial class QASelector : Form
    {

        private readonly Concert _c;
        private readonly Song _s;
        private readonly int _nr;
        private readonly List<sbyte> _indices = new List<sbyte>();

        public QASelector(Concert c, Song s, int nr)
        {
            InitializeComponent();
            _c = c;
            _s = s;
            _nr = nr;

            for (sbyte i = 0; i < 127; i++)
            {
                if (_c.LightConfig?.Names[i] == null || _c.LightConfig.Names[i] == string.Empty) continue;
                comboBox1.Items.Add(_c.LightConfig.Names[i]);
                _indices.Add(i);
            }

            sbyte val = _s.QA[_nr];
            if (val > -1) comboBox1.SelectedIndex = comboBox1.Items.IndexOf(_c.LightConfig.Names[val]);
        }

        private void button1_Click(object sender, EventArgs e) => Close();

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1) _s.QA[_nr] = _indices[comboBox1.SelectedIndex];
            Close();
        }
    }
}
