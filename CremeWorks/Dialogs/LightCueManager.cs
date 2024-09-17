using CremeWorks.App;

namespace CremeWorks
{
    public partial class LightCueManager : Form
    {
        private readonly IDataParent _parent;
        private readonly Random _rng = new Random();

        public LightCueManager(IDataParent parent)
        {
            _parent = parent;
            InitializeComponent();
        }

        private void LightCueManager_Load(object sender, System.EventArgs e) => UpdateBox();

        private void UpdateBox()
        {
            lstCues.Items.Clear();
            lstCues.Items.AddRange(_parent.Database.LightingCues.Select(x => new LightingCueItem(x.Key, x.Value.Name, x.Value.NoteValue)).ToArray());

            //Enable/disable note val box if it contains a value already in the list to prevent doubles
            var curVal = (byte)txtNoteOn.Value;
            btnAdd.Enabled = !_parent.Database.LightingCues.Any(x => x.Value.NoteValue == curVal);
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            if (lstCues.SelectedItem is not LightingCueItem lc) return;
            _parent.Database.LightingCues.Remove(lc.ID);
            UpdateBox();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            _parent.Database.LightingCues.Add(Random.Shared.Next(), new App.Data.LightingCueItem((byte)txtNoteOn.Value, txtName.Text));
            UpdateBox();
        }

        private async void btnTrigger_Click(object sender, System.EventArgs e)
        {
            if (lstCues.SelectedItem is not LightingCueItem lc) return;
            await _parent.MidiManager.SendToLighting(lc.NoteValue);
        }

        private void txtNoteOn_ValueChanged(object sender, System.EventArgs e)
        {
            var curVal = (byte)txtNoteOn.Value;
            btnAdd.Enabled = !_parent.Database.LightingCues.Any(x => x.Value.NoteValue == curVal);
        }

        private record LightingCueItem(int ID, string Name, byte NoteValue)
        {
            public override string ToString() => $"{Name}(#{NoteValue})";
        }
    }
}
