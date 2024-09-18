using CremeWorks.App;
using CremeWorks.App.Data;

namespace CremeWorks.App.Dialogs.Songs
{
    public partial class SongCueEditor : Form
    {
        private string _comment;
        private int _id;
        private readonly KeyValuePair<int, LightingCueItem>[] _availableCues;

        private SongCueEditor(IDataParent parent, string comment = "Empty", int id = 0)
        {
            InitializeComponent();
            _comment = comment;
            _id = id;
            _availableCues = parent.Database.LightingCues.ToArray();
        }


        public static bool EditCue(IDataParent parent, ref CueInstance item)
        {
            var inst = new SongCueEditor(parent, item.Description, item.CueId);
            if (inst.ShowDialog() == DialogResult.OK && inst._id > 0)
            {
                item.Description = inst._comment;
                item.CueId = inst._id;
                return true;
            }
            return false;
        }

        public static bool AddToCue(IDataParent parent, out CueInstance item)
        {
            var inst = new SongCueEditor(parent);
            if (inst.ShowDialog() == DialogResult.OK && inst._id > 0)
            {
                item = new CueInstance
                {
                    Description = inst._comment,
                    CueId = inst._id
                };
                return true;
            }

            item = default;
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a cue!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a comment!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            _comment = textBox1.Text;
            _id = _availableCues.FirstOrDefault(x => x.Value.Name == (string)comboBox1.SelectedItem!).Key;
            Close();
        }

        private void button2_Click(object sender, EventArgs e) => Close();

        private void LightCueEditor_Load(object sender, EventArgs e)
        {
            var el = _availableCues.FirstOrDefault(x => x.Key == _id);

            textBox1.Text = _comment;
            comboBox1.Items.AddRange(_availableCues.Select(x => x.Value.Name).ToArray());
            comboBox1.SelectedIndex = el.Key == 0 ? -1 : Array.IndexOf(_availableCues, el) + 1;
        }
    }
}
