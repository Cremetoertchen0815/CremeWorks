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
    public partial class QASelector : Form
    {

        private Concert _c;
        private Song _s;
        private int _nr;
        private List<int> _indices = new List<int>();

        public QASelector(Concert c, Song s, int nr)
        {
            InitializeComponent();
            _c = c;
            _s = s;
            _nr = nr;

            for (int i = 0; i < 128; i++)
            {
                if (_c.LightConfig?.Names[i] == null || _c.LightConfig.Names[i] == string.Empty) continue;
                comboBox1.Items.Add(_c.LightConfig.Names[i]);
                _indices.Add(i);
            }

            var val = _s.QA[_nr];
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
