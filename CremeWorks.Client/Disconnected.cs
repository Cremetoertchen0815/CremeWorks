using CremeWorks.Client.Networking;

namespace CremeWorks.Client;
public partial class Disconnected : Form
{
    private readonly CommunicationHub _netHub;

    public Disconnected(CommunicationHub netHub)
    {
        InitializeComponent();
        _netHub = netHub;
    }

    private async void Disconnected_Load(object sender, EventArgs e)
    {
        bool result = false;
        try
        {
            result = await _netHub.Connect();
        }
        catch (Exception)
        {
        }

        if (!result)
        {
            MessageBox.Show("Reconnecting to server failed! Closing application...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
        Close();
    }
}
