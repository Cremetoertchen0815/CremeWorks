using CremeWorks.App.Data;
using System.Data;

namespace CremeWorks.App.Dialogs.Playlist;
public partial class SelectSongDialog : Form
{
    public int? SelectedSongId => (boxSelector.SelectedItem as SongComboboxItem)?.Id;
    private readonly bool _addNullObject;

    public SelectSongDialog(Database db, bool addNullObject, int? defaultId = null)
    {
        InitializeComponent();
        _addNullObject = addNullObject;

        if (addNullObject) boxSelector.Items.Add("-");
        var songs = db.Songs.OrderBy(s => s.Value.Artist).ThenBy(s => s.Value.Title).Select(x => new SongComboboxItem(x.Value.Title, x.Value.Artist, x.Key)).ToArray();
        boxSelector.Items.AddRange(songs);
        if (defaultId.HasValue)
        {
            boxSelector.SelectedItem = songs.FirstOrDefault(x => x.Id == defaultId) ?? boxSelector.Items[0];
        }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        if (boxSelector.SelectedItem == null && !_addNullObject)
        {
            MessageBox.Show("Please select a song!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private record SongComboboxItem(string Title, string Artist, int Id)
    {
        public override string ToString() => $"{Artist} - {Title}";
    }
}
