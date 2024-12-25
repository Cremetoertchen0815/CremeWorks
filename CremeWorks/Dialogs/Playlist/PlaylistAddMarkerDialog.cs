using CremeWorks.App.Data;
using CremeWorks.App.Dialogs.Songs;

namespace CremeWorks.App.Dialogs.Playlist;

public partial class PlaylistAddMarkerDialog : Form
{
    private readonly MarkerPlaylistEntry _entry;
    private readonly IDataParent _parent;

    public PlaylistAddMarkerDialog(IDataParent parent, MarkerPlaylistEntry entry)
    {
        InitializeComponent();
        _entry = entry;
        _parent = parent;
        txtTitle.Text = entry.Text;
        txtInstructions.Text = entry.Instructions;

        lstCues.Items.AddRange(entry.Cues.Select(x => new ComboBoxCueItem(x, _parent.Database.LightingCues[x.CueId])).ToArray());
    }


    private void btnCueAdd_Click(object sender, EventArgs e)
    {
        if (SongCueEditor.AddToCue(_parent, out var cueInstance))
        {
            var cue = _parent.Database.LightingCues[cueInstance.CueId];
            var cbi = new ComboBoxCueItem(cueInstance, cue);
            lstCues.Items.Add(cbi);
        }
    }

    private void btnCueEdit_Click(object sender, EventArgs e)
    {
        if (lstCues.SelectedIndex < 0) return;
        var cbi = (ComboBoxCueItem)lstCues.SelectedItem!;
        var cueInstance = cbi.Instance;

        if (SongCueEditor.EditCue(_parent, ref cueInstance))
        {
            cbi.Instance = cueInstance;
            cbi.LightingCueItem = _parent.Database.LightingCues[cueInstance.CueId];
            lstCues.Items[lstCues.SelectedIndex] = cbi;
        }

    }

    private void btnCueDuplicate_Click(object sender, EventArgs e)
    {
        if (lstCues.SelectedIndex < 0) return;
        var cbi = (ComboBoxCueItem)lstCues.SelectedItem!;
        var newCbi = new ComboBoxCueItem(cbi.Instance, cbi.LightingCueItem);
        lstCues.Items.Add(newCbi);
    }

    private void btnCueRemove_Click(object sender, EventArgs e)
    {
        if (lstCues.SelectedIndex < 0) return;
        lstCues.Items.RemoveAt(lstCues.SelectedIndex);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {

        if (string.IsNullOrWhiteSpace(txtTitle.Text))
        {
            MessageBox.Show("Please enter a title for the marker!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        DialogResult = DialogResult.OK;
        _entry.Text = txtTitle.Text;
        _entry.Instructions = txtInstructions.Text;
        _entry.Cues.Clear();
        foreach (var item in lstCues.Items)
        {
            var cbi = (ComboBoxCueItem)item;
            _entry.Cues.Add(cbi.Instance);
        }

        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }


    private class ComboBoxCueItem
    {
        public CueInstance Instance { get; set; }
        public LightingCueItem LightingCueItem { get; set; }

        public ComboBoxCueItem(CueInstance instance, LightingCueItem lightingCueItem)
        {
            LightingCueItem = lightingCueItem;
            Instance = instance;
        }

        public override string ToString() => $"{Instance.Description} ({LightingCueItem.Name})";
    }

    private void lstCues_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if (lstCues.IndexFromPoint(new Point(e.X, e.Y)) < 0) return;
        btnCueEdit_Click(sender, e);
    }
}
