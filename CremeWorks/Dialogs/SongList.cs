using CremeWorks.App;
using CremeWorks.App.Data;

namespace CremeWorks;

public partial class SongList : Form
{

    private IDataParent _parent;
    public SongList(IDataParent parent)
    {
        InitializeComponent();
        _parent = parent;

        foreach (var s in _parent.Database.Songs)
        {
            var lvi = new ListViewItem(s.Value.Title);
            lvi.SubItems.Add(s.Key.ToString());
            lvi.SubItems.Add(s.Value.Artist);
            lvi.Tag = s.Key;
            lstSongs.Items.Add(lvi);
        }

        lstSongs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        lstSongs.Sort();
    }

    private void btnCreate_Click(object sender, EventArgs e)
    {
        var nuSong = new Song();
        var id = Random.Shared.Next();
        _parent.Database.Songs.Add(id, nuSong);
        var lvi = new ListViewItem(nuSong.Title);
        lvi.SubItems.Add(id.ToString());
        lvi.SubItems.Add(nuSong.Artist);
        lvi.Tag = id;
        lstSongs.Items.Add(lvi);
        lstSongs.Sort();
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (lstSongs.SelectedItems.Count == 0) return;
        var lvi = lstSongs.SelectedItems[0];
        var id = (int)lstSongs.Tag!;

        var song = _parent.Database.Songs[id];
        var editor = new SongEditor(_parent, id);
        editor.ShowDialog();

        if (editor.DialogResult == DialogResult.OK)
        {
            lvi.SubItems[0].Text = song.Title;
            lvi.SubItems[2].Text = song.Artist;
        }

        lstSongs.Sort();
    }

    private void btnDuplicate_Click(object sender, EventArgs e)
    {
        if (lstSongs.SelectedItems.Count == 0) return;
        var lvi = lstSongs.SelectedItems[0];
        var id = (int)lstSongs.Tag!;

        var song = _parent.Database.Songs[id];
        var nuSong = song.Clone();
        var nuId = Random.Shared.Next();

        _parent.Database.Songs.Add(nuId, nuSong);
        var lvi2 = new ListViewItem(nuSong.Title);
        lvi2.SubItems.Add(nuId.ToString());
        lvi2.SubItems.Add(nuSong.Artist);
        lvi2.Tag = nuId;
        lstSongs.Items.Add(lvi2);
        lstSongs.Sort();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (lstSongs.SelectedItems.Count == 0) return;
        var lvi = lstSongs.SelectedItems[0];
        var id = (int)lstSongs.Tag!;

        if (MessageBox.Show("Are you sure you want to delete this song?", "Delete Song", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes) return;

        _parent.Database.Songs.Remove(id);
        lstSongs.Items.Remove(lvi);
        lstSongs.Sort();
    }
}