using CremeWorks.App.Data;
using CremeWorks.App.Dialogs.Playlist;
using System;
using System.ComponentModel;

namespace CremeWorks.App.Dialogs;
public partial class PlaylistEditor : Form
{
    private readonly IDataParent _parent;
    private readonly BindingList<PlaylistComboboxItem> _comboItems = [];
    private bool _canDataBeUpdated = true;

    public PlaylistEditor(IDataParent parent)
    {
        _parent = parent;
        InitializeComponent();
        // Double buffer the list view to prevent flickering
        typeof(Control).GetProperty("DoubleBuffered",
                             System.Reflection.BindingFlags.NonPublic |
                             System.Reflection.BindingFlags.Instance)?
               .SetValue(lstEntries, true, null);

        // Populate the combo box with the existing playlists
        boxSelector.DataSource = new BindingSource(_comboItems, null);
        foreach (var item in parent.Database.Playlists)
        {
            var pci = new PlaylistComboboxItem(item.Name, item.Date);
            pci.PlaylistEntries.AddRange(item.Elements);
            _comboItems.Add(pci);
        }
    }

    private void btnPlus_Click(object sender, EventArgs e)
    {
        var item = new PlaylistComboboxItem("New Playlist", DateOnly.FromDateTime(DateTime.Now));
        _comboItems.Add(item);
        boxSelector.Text = item.ToString();
        boxSelector.SelectedItem = item;
        boxSelector_SelectedIndexChanged(sender, e);
    }

    private void btnMinus_Click(object sender, EventArgs e)
    {
        if (boxSelector.SelectedItem is not PlaylistComboboxItem item) return;
        _comboItems.Remove(item);
        boxSelector.SelectedIndex = boxSelector.Items.Count - 1;
        if (boxSelector.SelectedIndex < 0)
        {
            boxSelector.Text = string.Empty;
        }
    }

    private void boxSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        _canDataBeUpdated = false;
        var item = boxSelector.SelectedItem as PlaylistComboboxItem;
        groupBox1.Enabled = item is not null;
        txtName.Text = item?.Name ?? string.Empty;
        txtDate.Value = item?.Date.ToDateTime(TimeOnly.MinValue) ?? DateTime.Now;
        lstEntries.Items.Clear();
        if (item is not null)
        {
            int playlistIndex = 1;
            foreach (var entry in item.PlaylistEntries)
            {
                if (entry is SongPlaylistEntry songEntry)
                {
                    if (!_parent.Database.Songs.TryGetValue(songEntry.SongId, out var song)) continue;
                    var lvi = new ListViewItem(playlistIndex++.ToString());
                    lvi.SubItems.Add(song.Title);
                    lvi.SubItems.Add(song.Artist.ToString());
                    lvi.SubItems.Add("Song");
                    lvi.SubItems.Add(TimeSpan.FromSeconds(song.ExpectedDurationSeconds).ToString(@"mm\:ss"));
                    lvi.Tag = entry;
                    lstEntries.Items.Add(lvi);
                }
                else if (entry is MarkerPlaylistEntry marker)
                {
                    var lvi = new ListViewItem("");
                    lvi.SubItems.Add(marker.Text);
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("Marker");
                    lvi.SubItems.Add("-");
                    lvi.Tag = entry;
                    lstEntries.Items.Add(lvi);
                }
            }
        }
        _canDataBeUpdated = true;
    }

    private void txtName_TextChanged(object sender, EventArgs e)
    {
        if (!_canDataBeUpdated || boxSelector.SelectedItem is not PlaylistComboboxItem item) return;
        item.Name = txtName.Text;
        _comboItems.ResetItem(boxSelector.SelectedIndex);
    }

    private void txtDate_ValueChanged(object sender, EventArgs e)
    {
        if (!_canDataBeUpdated || boxSelector.SelectedItem is not PlaylistComboboxItem item) return;
        item.Date = DateOnly.FromDateTime(txtDate.Value);
        _comboItems.ResetItem(boxSelector.SelectedIndex);
    }

    private void btnAddSong_Click(object sender, EventArgs e)
    {
        if (boxSelector.SelectedItem is not PlaylistComboboxItem item) return;
        var dialog = new PlaylistAddSongDialog(_parent);
        if (dialog.ShowDialog() != DialogResult.OK) return;
        var songId = dialog.SelectedSongId;
        if (!_parent.Database.Songs.TryGetValue(songId, out var song)) return;

        var entry = new SongPlaylistEntry(songId);
        item.PlaylistEntries.Add(entry);
        lstEntries.Items.Add(new ListViewItem(new[] 
        {
            item.PlaylistEntries.Count(x => x is SongPlaylistEntry).ToString(), 
            song.Title, 
            song.Artist.ToString(), 
            "Song", 
            TimeSpan.FromSeconds(song.ExpectedDurationSeconds).ToString(@"mm\:ss") 
        }) { Tag = entry });
    }
}

public class PlaylistComboboxItem(string name, DateOnly date)
{
    public string Name { get; set; } = name;
    public DateOnly Date { get; set; } = date;
    public List<IPlaylistEntry> PlaylistEntries { get; set; } = [];

    public override string ToString() => $"{Name} ({Date})";
}