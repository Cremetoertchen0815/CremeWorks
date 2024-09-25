using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CremeWorks.App.Dialogs.Cloud;
public partial class PublishDialog : Form
{
    public PublishDialog()
    {
        InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            MessageBox.Show("Please enter a name!", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    public static bool OpenWindow(out string name, out bool isPublic)
    {
        name = string.Empty;
        isPublic = false;

        var dialog = new PublishDialog();
        if (dialog.ShowDialog() != DialogResult.OK) return false;
        name = dialog.txtName.Text;
        isPublic = dialog.chkPublic.Checked;
        return true;
    }
}
