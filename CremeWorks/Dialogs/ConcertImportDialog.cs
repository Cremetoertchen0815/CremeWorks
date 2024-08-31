using CremeWorks.App.Data;
using CremeWorks.App.Data.Compatibility;
using CremeWorks.App.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OldSong = CremeWorks.App.Data.Compatibility.Song;
using NewSong = CremeWorks.App.Data.Song;
using CremeWorks.App.Dialogs.Playlist;

namespace CremeWorks.App.Dialogs;
public partial class ConcertImportDialog : Form
{
    public ConcertConversionConfig Config { get; private set; }
    private List<int?> _songRemapIds = new();
    private readonly Database _db;

    public ConcertImportDialog(Concert concert, Database db, string name)
    {
        _db = db;
        InitializeComponent();

        // Set default values
        chkActions.Checked = Settings.Default.ImportActions;
        chkPlaylist.Checked = txtPlaylist.Enabled = Settings.Default.ImportCreatePlaylist;
        txtPlaylist.Text = name;
        boxDoubles.SelectedIndex = Settings.Default.ImportDoubles;
        boxRouting.SelectedIndex = Settings.Default.ImportRouting;
        boxPatches.SelectedIndex = Settings.Default.ImportPatches;

        // Set song list
        var songs = concert.Playlist.Where(x => !x.SpecialEvent).ToArray();
        foreach (var s in songs)
        {
            var doubleItem = FindDouble(s);
            var i = lstSongs.Items.Add($"{s.Title}");
            i.SubItems.Add(s.Artist);
            i.SubItems.Add(doubleItem?.ToString() ?? "-");
            i.Tag = s;
            i.Checked = true;
        }
    }

    private int? FindDouble(OldSong s) => _db.Songs.Select(x => (KeyValuePair<int, NewSong>?)x).FirstOrDefault(x => x!.Value.Value.Title.Equals(s.Title, StringComparison.InvariantCultureIgnoreCase) && x!.Value.Value.Artist.Equals(s.Artist, StringComparison.InvariantCultureIgnoreCase))?.Key;

    private void ImportDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
        Settings.Default.ImportActions = chkActions.Checked;
        Settings.Default.ImportCreatePlaylist = chkPlaylist.Checked;
        Settings.Default.ImportDoubles = boxDoubles.SelectedIndex;
        Settings.Default.ImportRouting = boxRouting.SelectedIndex;
        Settings.Default.ImportPatches = boxPatches.SelectedIndex;
        Settings.Default.Save();

        if (DialogResult == DialogResult.OK)
        {
            var _importSong = lstSongs.Items.Cast<ListViewItem>().Select(x => x.Checked).ToArray();
            var _songRemapIds = lstSongs.Items.Cast<ListViewItem>().Select<ListViewItem, int?>(x => x.Checked && int.TryParse(x.SubItems[2].Text, out var id) ? id : null).ToArray();
            Config = new ConcertConversionConfig
            {
                ImportActions = chkActions.Checked,
                PlaylistName = chkPlaylist.Checked ? txtPlaylist.Text : null,
                SongImportDoubleHandling = (SongImportDoubleHandling)boxDoubles.SelectedIndex,
                DefaultRoutingConversionMethod = (DefaultRoutingConversionType)boxRouting.SelectedIndex,
                PatchImportDoubleHandling = (PatchImportDoubleHandling)boxPatches.SelectedIndex,
                SongRemapIds = _songRemapIds,
                ImportSong = _importSong
            };
        }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    private void LstSongs_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right) return;
        var item = lstSongs.GetItemAt(e.X, e.Y);
        if (item is null) return;


        var dialog = new SelectSongDialog(_db, true, int.TryParse(item.SubItems[2].Text, out var id) ? id : null);
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            item.SubItems[2].Text = dialog.SelectedSongId?.ToString() ?? "-";
        }
    }
}
