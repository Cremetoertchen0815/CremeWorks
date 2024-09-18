using CremeWorks.App;
using CremeWorks.App.Data;
using CremeWorks.App.Dialogs.Songs;

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
            var lvi = new ListViewItem(s.Value.Artist);
            lvi.SubItems.Add(s.Value.Title);
            lvi.SubItems.Add(s.Key.ToString());
            lvi.Tag = s.Key;
            lstSongs.Items.Add(lvi);
        }

        lstSongs.Sort();
    }

    private void btnCreate_Click(object sender, EventArgs e)
    {
        var nuSong = new Song();
        var id = Random.Shared.Next();
        _parent.Database.Songs.Add(id, nuSong);
        var editor = new SongEditor(_parent, id);
        if (editor.ShowDialog() != DialogResult.OK)
        {
            _parent.Database.Songs.Remove(id);
            return;
        }

        var lvi = new ListViewItem(nuSong.Artist);
        lvi.SubItems.Add(nuSong.Title);
        lvi.SubItems.Add(id.ToString());
        lvi.Tag = id;
        lstSongs.Items.Add(lvi);
        lstSongs.Sort();
        lstSongs.SelectedItems.Clear();
        lvi.Selected = true;
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (lstSongs.SelectedItems.Count == 0) return;
        var lvi = lstSongs.SelectedItems[0];
        var id = (int)lvi.Tag!;

        var song = _parent.Database.Songs[id];
        var editor = new SongEditor(_parent, id);
        editor.ShowDialog();

        if (editor.DialogResult == DialogResult.OK)
        {
            lvi.SubItems[0].Text = song.Artist;
            lvi.SubItems[1].Text = song.Title;
        }

        lstSongs.Sort();
        lstSongs.SelectedItems.Clear();
        lvi.Selected = true;
    }

    private void btnDuplicate_Click(object sender, EventArgs e)
    {
        if (lstSongs.SelectedItems.Count == 0) return;
        var lvi = lstSongs.SelectedItems[0];
        var id = (int)lvi.Tag!;

        var song = _parent.Database.Songs[id];
        var nuSong = song.Clone();
        var nuId = Random.Shared.Next();

        _parent.Database.Songs.Add(nuId, nuSong);
        var lvi2 = new ListViewItem(nuSong.Artist);
        lvi2.SubItems.Add(nuSong.Title);
        lvi2.SubItems.Add(nuId.ToString());
        lvi2.Tag = nuId;
        lstSongs.Items.Add(lvi2);

        lstSongs.Sort();
        lstSongs.SelectedItems.Clear();
        lvi2.Selected = true;
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (lstSongs.SelectedItems.Count == 0) return;
        var lvi = lstSongs.SelectedItems[0];
        var id = (int)lvi.Tag!;

        if (MessageBox.Show("Are you sure you want to delete this song?", "Delete Song", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes) return;

        _parent.Database.Songs.Remove(id);
        lstSongs.Items.Remove(lvi);
        lstSongs.Sort();
        lstSongs.SelectedItems.Clear();

        // Remove all references to this song in the database
        foreach (var p in _parent.Database.Playlists)
        {
            p.Elements.Where(x => x is SongPlaylistEntry sp && sp.SongId == id).ToList().ForEach(x => p.Elements.Remove(x));
        }
    }
}