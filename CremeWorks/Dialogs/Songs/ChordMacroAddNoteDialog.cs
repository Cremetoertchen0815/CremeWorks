namespace CremeWorks.App.Dialogs.Songs;
public partial class ChordMacroAddNoteDialog : Form
{
    private readonly List<int> _usedIds;

    public ChordMacroAddNoteDialog(List<int> usedIds)
    {
        InitializeComponent();
        _usedIds = usedIds;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        int val = (int)numericUpDown1.Value;
        if (_usedIds.Contains(val))
        {
            MessageBox.Show("You can't add a note value twice!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    public static int? OpenDialog(List<int> usedIds)
    {
        using var dialog = new ChordMacroAddNoteDialog(usedIds);
        if (dialog.ShowDialog() != DialogResult.OK) return null;

        return (int)dialog.numericUpDown1.Value;
    }
}
