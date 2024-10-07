namespace CremeWorks.App.Dialogs.Cloud;
public partial class LoginDialog : Form
{
    private bool _didRegister = false;
    public LoginDialog(bool wasIncorrect)
    {
        InitializeComponent();
        lblIncorrect.Visible = wasIncorrect;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            MessageBox.Show("Please fill in both fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        _didRegister = false;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            MessageBox.Show("Please fill in both fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        _didRegister = true;
        DialogResult = DialogResult.OK;
        Close();
    }

    public static bool OpenWindow(bool wasIncorrect, out string username, out string password, out bool register)
    {
        var window = new LoginDialog(wasIncorrect);
        var success = window.ShowDialog() == DialogResult.OK;
        username = window.txtUsername.Text;
        password = window.txtPassword.Text;
        register = window._didRegister;
        return success;
    }
}
