using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CremeWorks
{
    public partial class LightCueEditor : Form
    {
        private string _comment = "Empty";
        private ulong _id = 0;
        private List<LightingCue> _availableCues;

        private LightCueEditor() => InitializeComponent();


        public static bool EditCue(List<LightingCue> availableCues, ref (ulong ID, string comment) item)
        {
            var inst = new LightCueEditor() { _comment = item.comment, _id = item.ID, _availableCues = availableCues };
            if (inst.ShowDialog() == DialogResult.OK && inst._id > 0)
            {
                item.comment = inst._comment;
                item.ID = (byte)inst._id;
                return true;
            }
            return false;
        }

        public static bool AddToCue(List<LightingCue> availableCues, List<(ulong, string)> songCues)
        {
            var inst = new LightCueEditor() { _availableCues = availableCues };
            if (inst.ShowDialog() == DialogResult.OK && inst._id > 0)
            {
                songCues.Add((inst._id, inst._comment));
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            _comment = textBox1.Text;
            _id = _availableCues.FirstOrDefault(x => x.Name == (string)comboBox1.SelectedItem)?.ID ?? 0;
            Close();
        }

        private void button2_Click(object sender, EventArgs e) => Close();

        private void LightCueEditor_Load(object sender, EventArgs e)
        {

            textBox1.Text = _comment;
            comboBox1.Items.AddRange(_availableCues.Select(x => (object)x.Name).ToArray());
            comboBox1.SelectedText = _availableCues.FirstOrDefault(x => x.ID == _id).Name ?? "-";
        }
    }
}
