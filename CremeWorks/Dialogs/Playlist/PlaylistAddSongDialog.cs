using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CremeWorks.App.Dialogs.Playlist;
public partial class PlaylistAddSongDialog : Form
{
    public int SelectedSongId => (boxSelector.SelectedItem as SongComboboxItem)?.Id ?? -1;

    public PlaylistAddSongDialog(IDataParent parent)
    {
        InitializeComponent();

        var songs = parent.Database.Songs.OrderBy(s => s.Value.Artist).ThenBy(s => s.Value.Title).Select(x => new SongComboboxItem(x.Value.Title, x.Value.Artist, x.Key)).ToList();
        boxSelector.DataSource = new BindingSource(songs, null);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
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
