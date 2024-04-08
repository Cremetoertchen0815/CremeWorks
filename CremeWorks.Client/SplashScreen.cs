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

    private async void SplashScreen_Shown(object sender, EventArgs e)
    {
        IPAddress[] clients = [];
        while (true)
        {
            var timeout = false;
            try
            {
                clients = await FindServer();
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
            if (timeout || clients.Length == 0)
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

            var serverIp = clients.Length == 1 ? clients[0] : ServerSelection.Show(clients);
            if (serverIp is null) break;
        }
    }

    private async Task<IPAddress[]> FindServer()
    {
        var serverList = new ConcurrentBag<IPAddress>();
        var finder = new ServerFinder();
        finder.ServerFound += serverList.Add;

        var cSource = new CancellationTokenSource(TimeSpan.FromSeconds(FIND_TIMEOUT_SEC));
        await finder.ListenAsync(cSource.Token);
        return serverList.ToArray();
    }
}
