using CremeWorks.DTO;

namespace CremeWorks.App.Dialogs.Cloud;
public partial class CloneDialog : Form
{
    public CloneDialog(CloudEntryInformation[] entries)
    {
        InitializeComponent();

        foreach (var item in entries)
        {
            var lvitem = new ListViewItem(item.Name);
            lvitem.Tag = item.Id;
            lvitem.SubItems.Add(item.Creator);
            lvitem.SubItems.Add(item.IsPublic ? "Yes" : "No");
            lvitem.SubItems.Add(item.LastTimeUpdated.ToString("f"));
            listView1.Items.Add(lvitem);
        }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        if (listView1.SelectedItems.Count != 1)
        {
            MessageBox.Show("Please select a database to clone!", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    public static int? OpenWindow(CloudEntryInformation[] entries)
    {
        var dialog = new CloneDialog(entries);
        if (dialog.ShowDialog() != DialogResult.OK) return null;
        return (int)dialog.listView1.SelectedItems[0].Tag!;
    }
}
