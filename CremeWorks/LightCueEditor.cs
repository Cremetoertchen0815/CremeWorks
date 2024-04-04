using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CremeWorks
{
    public partial class LightCueEditor : Form
    {
        private string _comment = "Empty";
        private int _cue = -1;
        private List<(string, byte)> _availableCues;

        private LightCueEditor() => InitializeComponent();


        public static bool EditCue(List<(string, byte)> availableCues, ref (string comment, byte cue) item)
        {
            var inst = new LightCueEditor() { _comment = item.comment, _cue = item.cue, _availableCues = availableCues };
            if (inst.ShowDialog() == DialogResult.OK && inst._cue >= 0)
            {
                item.comment = inst._comment;
                item.cue = (byte)inst._cue;
                return true;
            }
            return false;
        }

        public static bool AddToCue(List<(string, byte)> availableCues, List<(string, byte)> songCues)
        {
            var inst = new LightCueEditor() { _availableCues = availableCues };
            if (inst.ShowDialog() == DialogResult.OK && inst._cue >= 0)
            {
                songCues.Add((inst._comment, (byte)inst._cue));
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            _comment = textBox1.Text;
            _cue = _availableCues.Select(x => ToNullable(x)).FirstOrDefault(x => x?.Item1 == (string)comboBox1.SelectedItem)?.Item2 ?? -1;
            Close();
        }

        private T? ToNullable<T>(T obj) where T : struct => new T?(obj);

        private void button2_Click(object sender, EventArgs e) => Close();

        private void LightCueEditor_Load(object sender, EventArgs e)
        {

            textBox1.Text = _comment;
            comboBox1.Items.AddRange(_availableCues.Select(x => (object)x.Item1).ToArray());
            comboBox1.SelectedText = _availableCues.FirstOrDefault(x => x.Item2 == _cue).Item1 ?? "-";
        }
    }
}
