using CremeWorks.Client.Networking;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CremeWorks.Client;
public partial class SplashScreen : Form
{
    private const int FIND_TIMEOUT_SEC = 10;

    public SplashScreen() => InitializeComponent();

    private ServerFinder _finder = new();

    private async void SplashScreen_Shown(object sender, EventArgs e)
    {
        IPAddress? client = null;
        while (true)
        {
            lblStatus.Text = "Searching for server...";
            var timeout = false;
            try
            {
                client = await FindServer();
            }
            catch (OperationCanceledException)
            {
                timeout = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            //Check if servers can be found
            if (timeout || client == null)
            {
                var userAction = MessageBox.Show("No servers have been found! Do you want to retry?", "Server Scan Timeout", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                switch (userAction)
                {
                    case DialogResult.Yes:
                        break;
                    default:
                        Application.Exit();
                        return;
                }

                continue;
            }

            lblStatus.Text = "Connecting to client...";
            await Task.Delay(1000);

            var hub = new CommunicationHub(client);
            if (!await hub.Connect())
            {
                if (MessageBox.Show("Communication failed! Retry?", "Server Connection failed", MessageBoxButtons.YesNo, MessageBoxIcon.Error) != DialogResult.Yes)
                {
                    Application.Exit();
                    return;
                }
                continue;
            }

            //Start main form
            var main = new Form1(client);
            main.Show();
            Close();
            break;
        }
    }

    private async Task<IPAddress?> FindServer()
    {
        var cSource = new CancellationTokenSource(TimeSpan.FromSeconds(FIND_TIMEOUT_SEC));
        var result = await _finder.ListenAsync(cSource.Token);
        return result;
    }
}
