using CremeWorks.App.Data;
using CremeWorks.App.Data.Patches;

namespace CremeWorks.App.Dialogs.Patch;
public partial class AddPatchForm : Form
{
    public AddPatchForm()
    {
        InitializeComponent();
    }

    public static IDevicePatch? ShowNewDialog()
    {
        var form = new AddPatchForm();
        if (form.ShowDialog() != DialogResult.OK) return null;

        return form.cmbType.SelectedIndex switch
        {
            0 => new CSPatch(form.txtName.Text),
            1 => new CPPatch(form.txtName.Text),
            2 => new YCPatch(form.txtName.Text),
            _ => new ProgramChangePatch(form.txtName.Text)
        };
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            MessageBox.Show("Please enter a name for the patch!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }
}
