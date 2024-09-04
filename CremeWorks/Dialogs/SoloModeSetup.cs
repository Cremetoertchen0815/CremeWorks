using CremeWorks.App.Dialogs.SoloMode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CremeWorks.App.Dialogs;
public partial class SoloModeSetup : Form
{
    private readonly IDataParent _dataParent;
    public SoloModeSetup(IDataParent dataParent)
    {
        InitializeComponent();
        _dataParent = dataParent;

        groupBox1.Enabled = chkEnable.Checked = _dataParent.Database.SoloModeConfig.Enabled;
        nbrCC.Value = _dataParent.Database.SoloModeConfig.CCNumber;
        nbrDefault.Value = _dataParent.Database.SoloModeConfig.DefaultValue;
        nbrSolo.Value = _dataParent.Database.SoloModeConfig.SoloValue;
        nbrFadeDuration.Enabled = chkFade.Checked = _dataParent.Database.SoloModeConfig.FadeDurationSeconds.HasValue;
        if (_dataParent.Database.SoloModeConfig.FadeDurationSeconds.HasValue)
        {
            nbrFadeDuration.Value = (decimal)_dataParent.Database.SoloModeConfig.FadeDurationSeconds.Value;
        }

        boxDevices.Items.AddRange(_dataParent.Database.SoloModeConfig.Devices.Select(x => new DeviceItem(x, _dataParent.Database.Devices[x].Name)).ToArray());
    }

    private record DeviceItem(int Id, string Name)
    {
        public override string ToString() => Name;
    }

    private void chkEnable_CheckedChanged(object sender, EventArgs e) => groupBox1.Enabled = chkEnable.Checked;

    private void chkFade_CheckedChanged(object sender, EventArgs e) => nbrFadeDuration.Enabled = chkFade.Checked;

    private void btnRemove_Click(object sender, EventArgs e)
    {
        if (boxDevices.SelectedItem is not DeviceItem item) return;
        boxDevices.Items.Remove(item);
    }

    private void SoloModeSetup_FormClosed(object sender, FormClosedEventArgs e)
    {
        _dataParent.Database.SoloModeConfig.Enabled = chkEnable.Checked;
        _dataParent.Database.SoloModeConfig.CCNumber = (byte)nbrCC.Value;
        _dataParent.Database.SoloModeConfig.DefaultValue = (byte)nbrDefault.Value;
        _dataParent.Database.SoloModeConfig.SoloValue = (byte)nbrSolo.Value;
        _dataParent.Database.SoloModeConfig.FadeDurationSeconds = chkFade.Checked ? (float)nbrFadeDuration.Value : null;
        _dataParent.Database.SoloModeConfig.Devices.Clear();
        _dataParent.Database.SoloModeConfig.Devices.AddRange(boxDevices.Items.Cast<DeviceItem>().Select(x => x.Id));
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        var usedIds = boxDevices.Items.Cast<DeviceItem>().Select(x => x.Id).ToArray();
        var id = SoloDeviceAdd.OpenDialog(_dataParent, usedIds);
        if (id.HasValue)
        {
            var device = _dataParent.Database.Devices[id.Value];
            boxDevices.Items.Add(new DeviceItem(id.Value, device.Name));
        }
    }
}
