using System;
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
public partial class ServerSelection : Form
{
    public ServerSelection()
    {
        InitializeComponent();
        DialogResult = DialogResult.Cancel;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (listBox1.SelectedIndex < 0)
        {
            MessageBox.Show("Please select item!");
            return;
        }
        DialogResult = DialogResult.OK;
        Close();
    }

    public static IPAddress? Show(IPAddress[] addresses)
    {
        var form = new ServerSelection();
        form.listBox1.Items.AddRange(addresses.Select(x => (object)x.ToString()).ToArray());
        if (form.ShowDialog() != DialogResult.OK) return null;
        return addresses[form.listBox1.SelectedIndex];
    }
}
