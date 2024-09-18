using CremeWorks.App.Data;
using CremeWorks.App.Dialogs.Playlist;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CremeWorks.App.Dialogs;
public partial class PlaylistEditor : Form
{
    private readonly IDataParent _parent;
    private readonly BindingList<PlaylistComboboxItem> _comboItems = [];
    private bool _canDataBeUpdated = true;
    private ListViewItem? draggedItem;

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

        // Select the first item
        if (_comboItems.Count > 0)
        {
            boxSelector.SelectedIndex = 0;
            boxSelector_SelectedIndexChanged(this, EventArgs.Empty);
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
        CalculateTotalDuration();
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
        var dialog = new SelectSongDialog(_parent.Database, false, null);
        if (dialog.ShowDialog() != DialogResult.OK || dialog.SelectedSongId is null) return;
        var songId = dialog.SelectedSongId.Value;
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
        })
        { Tag = entry });
        CalculateTotalDuration();
    }

    private void btnAddMarker_Click(object sender, EventArgs e)
    {
        if (boxSelector.SelectedItem is not PlaylistComboboxItem item) return;

        var nuItem = new MarkerPlaylistEntry() { Text = "New Marker" };
        var dialog = new PlaylistAddMarkerDialog(_parent, nuItem);
        if (dialog.ShowDialog() != DialogResult.OK) return;

        item.PlaylistEntries.Add(nuItem);
        lstEntries.Items.Add(new ListViewItem(new[]
        {
            string.Empty,
            nuItem.Text,
            "-",
            "Marker",
            "-"
        })
        { Tag = nuItem });
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (boxSelector.SelectedItem is not PlaylistComboboxItem item || lstEntries.SelectedItems.Count == 0) return;
        var entry = lstEntries.SelectedItems[0].Tag as IPlaylistEntry;

        if (entry is SongPlaylistEntry song)
        {
            var dialog = new SelectSongDialog(_parent.Database, false, song.SongId);
            if (dialog.ShowDialog() != DialogResult.OK || dialog.SelectedSongId is null) return;
            var songId = dialog.SelectedSongId.Value;
            if (!_parent.Database.Songs.TryGetValue(songId, out var newSong)) return;
            song.SongId = songId;
            lstEntries.SelectedItems[0].SubItems[1].Text = newSong.Title;
            lstEntries.SelectedItems[0].SubItems[2].Text = newSong.Artist.ToString();
            lstEntries.SelectedItems[0].SubItems[4].Text = TimeSpan.FromSeconds(newSong.ExpectedDurationSeconds).ToString(@"mm\:ss");
        }
        else if (entry is MarkerPlaylistEntry marker)
        {
            var dialog = new PlaylistAddMarkerDialog(_parent, marker);
            if (dialog.ShowDialog() != DialogResult.OK) return;
            lstEntries.SelectedItems[0].SubItems[1].Text = marker.Text;
        }

        CalculateTotalDuration();
    }

    private void btnUp_Click(object sender, EventArgs e)
    {
        if (boxSelector.SelectedItem is not PlaylistComboboxItem item || lstEntries.SelectedItems.Count == 0) return;
        var index = lstEntries.SelectedIndices[0];
        if (index == 0) return;
        var entry = item.PlaylistEntries[index];
        item.PlaylistEntries.RemoveAt(index);
        item.PlaylistEntries.Insert(index - 1, entry);
        //Modify the list view
        var lvi = lstEntries.Items[index];
        lstEntries.Items.RemoveAt(index);
        lstEntries.Items.Insert(index - 1, lvi);

        FixSongNumeration();
    }

    private void btnDown_Click(object sender, EventArgs e)
    {
        if (boxSelector.SelectedItem is not PlaylistComboboxItem item || lstEntries.SelectedItems.Count == 0) return;
        var index = lstEntries.SelectedIndices[0];
        if (index == item.PlaylistEntries.Count - 1) return;
        var entry = item.PlaylistEntries[index];
        item.PlaylistEntries.RemoveAt(index);
        item.PlaylistEntries.Insert(index + 1, entry);
        //Modify the list view
        var lvi = lstEntries.Items[index];
        lstEntries.Items.RemoveAt(index);
        lstEntries.Items.Insert(index + 1, lvi);

        FixSongNumeration();
    }

    private void btnDuplicate_Click(object sender, EventArgs e)
    {
        if (boxSelector.SelectedItem is not PlaylistComboboxItem item || lstEntries.SelectedItems.Count == 0) return;
        var entry = lstEntries.SelectedItems[0].Tag as IPlaylistEntry;
        if (entry is SongPlaylistEntry song)
        {
            var newEntry = new SongPlaylistEntry(song.SongId);
            item.PlaylistEntries.Add(newEntry);
            lstEntries.Items.Add(new ListViewItem(new[]
            {
                item.PlaylistEntries.Count(x => x is SongPlaylistEntry).ToString(),
                lstEntries.SelectedItems[0].SubItems[1].Text,
                lstEntries.SelectedItems[0].SubItems[2].Text,
                "Song",
                lstEntries.SelectedItems[0].SubItems[4].Text
            })
            { Tag = newEntry });
        }
        else if (entry is MarkerPlaylistEntry marker)
        {
            var newEntry = new MarkerPlaylistEntry() { Text = marker.Text };
            item.PlaylistEntries.Add(newEntry);
            lstEntries.Items.Add(new ListViewItem(new[]
            {
                string.Empty,
                marker.Text,
                "-",
                "Marker",
                "-"
            })
            { Tag = newEntry });
        }
        FixSongNumeration();
        CalculateTotalDuration();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (boxSelector.SelectedItem is not PlaylistComboboxItem item || lstEntries.SelectedItems.Count == 0) return;
        var entityToRemove = lstEntries.SelectedItems[0].Tag as IPlaylistEntry;
        if (entityToRemove is not null) item.PlaylistEntries.Remove(entityToRemove);
        lstEntries.Items.Remove(lstEntries.SelectedItems[0]);
        FixSongNumeration();
        CalculateTotalDuration();
    }

    private void PlaylistEditor_FormClosing(object sender, FormClosingEventArgs e)
    {
        _parent.Database.Playlists.Clear();
        foreach (var item in _comboItems)
        {
            var playlist = new Data.Playlist();
            playlist.Name = item.Name;
            playlist.Date = item.Date;
            playlist.Elements.AddRange(item.PlaylistEntries);
            _parent.Database.Playlists.Add(playlist);
        }
    }

    private void lstEntries_ItemDrag(object sender, ItemDragEventArgs e)
    {
        // Start dragging the item
        draggedItem = (ListViewItem?)e.Item;
        if (draggedItem is null) return;
        DoDragDrop(draggedItem, DragDropEffects.Move);
    }

    private void lstEntries_DragEnter(object sender, DragEventArgs e)
    {
        // Allow move operation
        if (e.Data?.GetDataPresent(typeof(ListViewItem)) == true)
        {
            e.Effect = DragDropEffects.Move;
        }
        else
        {
            e.Effect = DragDropEffects.None;
        }
    }

    private void lstEntries_DragOver(object sender, DragEventArgs e)
    {
        // Ensure the effect is Move while dragging over
        e.Effect = DragDropEffects.Move;

        // Get the location in the ListView
        Point point = lstEntries.PointToClient(new Point(e.X, e.Y));

        // Get the target item under the mouse
        ListViewItem? targetItem = lstEntries.GetItemAt(point.X, point.Y);

        // Highlight the target item for better user experience
        if (targetItem != null && targetItem != draggedItem)
        {
            targetItem.Selected = true;
            targetItem.Focused = true;
        }
    }

    private void lstEntries_DragDrop(object sender, DragEventArgs e)
    {
        // Get the drop point
        Point point = lstEntries.PointToClient(new Point(e.X, e.Y));

        // Get the target item
        ListViewItem? targetItem = lstEntries.GetItemAt(point.X, point.Y);

        if (targetItem != null && draggedItem != null)
        {
            // Find the indices of the dragged item and target item
            int draggedIndex = draggedItem.Index;
            int targetIndex = targetItem.Index;

            // Remove the dragged item
            var playlist = boxSelector.SelectedItem as PlaylistComboboxItem;
            if (playlist is null) return;
            var entry = playlist.PlaylistEntries[draggedIndex];
            playlist.PlaylistEntries.RemoveAt(draggedIndex);
            lstEntries.Items.RemoveAt(draggedIndex);

            // Insert it at the target location
            playlist.PlaylistEntries.Insert(targetIndex, entry);
            lstEntries.Items.Insert(targetIndex, draggedItem);

            FixSongNumeration();


            // Clear the selection
            draggedItem.Selected = false;
            draggedItem.Focused = false;

            // Re-select and focus the moved item for visibility
            lstEntries.Items[targetIndex].Selected = true;
            lstEntries.Items[targetIndex].Focused = true;
        }
    }

    private void FixSongNumeration()
    {
        int playlistIndex = 1;
        foreach (ListViewItem item in lstEntries.Items)
        {
            if (item.Tag is SongPlaylistEntry)
            {
                item.SubItems[0].Text = playlistIndex++.ToString();
            }
        }
    }

    private void CalculateTotalDuration()
    {
        var duration = lstEntries.Items.OfType<ListViewItem>().Select(x => x.Tag as SongPlaylistEntry).Where(x => x is not null).Sum(x => _parent.Database.Songs[x!.SongId].ExpectedDurationSeconds);
        lblDuration.Text = TimeSpan.FromSeconds(duration).ToString(@"hh\:mm\:ss");
    }

    private void lstEntries_MouseDoubleClick(object sender, MouseEventArgs e) => btnEdit_Click(sender, e);
}

public class PlaylistComboboxItem(string name, DateOnly date)
{
    public string Name { get; set; } = name;
    public DateOnly Date { get; set; } = date;
    public List<IPlaylistEntry> PlaylistEntries { get; set; } = [];

    public override string ToString() => $"{Name} ({Date})";
}