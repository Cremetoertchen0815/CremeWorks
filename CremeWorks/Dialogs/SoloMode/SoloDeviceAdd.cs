using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CremeWorks.App.Dialogs.SoloMode;
public partial class SoloDeviceAdd : Form
{

    private readonly IDataParent _dataParent;

    public SoloDeviceAdd(IDataParent parent, int[] usedIds)
    {
        InitializeComponent();
        _dataParent = parent;

        boxDevices.Items.AddRange(_dataParent.Database.Devices.Select(x => new DeviceItem(x.Key, x.Value.Name)).Where(x => !usedIds.Contains(x.Id)).ToArray());
        if (boxDevices.Items.Count > 0) boxDevices.SelectedIndex = 0;
    }

    private record DeviceItem(int Id, string Name)
    {
        public override string ToString() => Name;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    public static int? OpenDialog(IDataParent parent, int[] usedIds)
    {
        using var dialog = new SoloDeviceAdd(parent, usedIds);
        if (dialog.ShowDialog() != DialogResult.OK) return null;

        if (dialog.boxDevices.SelectedItem is not DeviceItem item) return null;
        return item.Id;
    }
}
