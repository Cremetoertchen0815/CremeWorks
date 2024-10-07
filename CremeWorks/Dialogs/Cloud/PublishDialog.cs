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

    public static bool OpenWindow(ref string name, ref bool isPublic)
    {
        var dialog = new PublishDialog();
        dialog.txtName.Text = name;
        dialog.chkPublic.Checked = isPublic;
        if (dialog.ShowDialog() != DialogResult.OK) return false;
        name = dialog.txtName.Text;
        isPublic = dialog.chkPublic.Checked;
        return true;
    }
}
