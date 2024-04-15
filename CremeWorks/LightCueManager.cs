using System;
using System.Linq;
using System.Windows.Forms;

namespace CremeWorks
{
    public partial class LightCueManager : Form
    {
        private readonly Concert _c;
        private readonly Random _rng = new Random();

        public LightCueManager(Concert c)
        {
            _c = c;
            InitializeComponent();
        }

        private void LightCueManager_Load(object sender, System.EventArgs e) => UpdateBox();

        private void UpdateBox()
        {
            lstCues.Items.Clear();
            lstCues.Items.AddRange(_c.LightingCues.Select(x => (object)$"{x.Name}(#{x.NoteValue})").ToArray());

            //Enable/disable note val box if it contains a value already in the list to prevent doubles
            var curVal = (byte)txtNoteOn.Value;
            btnAdd.Enabled = !_c.LightingCues.Any(x => x.NoteValue == curVal);
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            if (lstCues.SelectedIndex < 0) return;
            _c.LightingCues.RemoveAt(lstCues.SelectedIndex);
            UpdateBox();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            _c.LightingCues.Add(new LightingCue() { ID = NextUInt64 (), Name = txtName.Text, NoteValue = (byte)txtNoteOn.Value });
            UpdateBox();
        }

        private void btnTrigger_Click(object sender, System.EventArgs e)
        {
            if (lstCues.SelectedIndex < 0) return;
            var noteVal = _c.LightingCues[lstCues.SelectedIndex];
        }

        private void txtNoteOn_ValueChanged(object sender, System.EventArgs e)
        {
            var curVal = (byte)txtNoteOn.Value;
            btnAdd.Enabled = !_c.LightingCues.Any(x => x.NoteValue == curVal);
        }

        public ulong NextUInt64()
        {
            var buffer = new byte[8];
            _rng.NextBytes(buffer);
            return BitConverter.ToUInt64(buffer, 0);

        }
    }
}
