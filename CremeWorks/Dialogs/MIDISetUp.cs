using CremeWorks.App;
using CremeWorks.App.Data;
using System.Data;

namespace CremeWorks;

public partial class MidiSetUp : Form
{

    private readonly IDataParent _parent;
    private bool _canDataBeUpdated = true;

    public MidiSetUp(IDataParent parent)
    {
        InitializeComponent();
        _parent = parent;
        boxSelector.Items.Add(new ComboBoxDeviceItem("-", -1, string.Empty, MidiDeviceType.Unknown, false));
        boxSelector.Items.AddRange(_parent.Database.Devices.Select(x => new ComboBoxDeviceItem(x.Value.Name, x.Key, x.Value.MidiId, x.Value.Type, x.Value.IsRemoteSource)).ToArray());
    }

    private void MIDISetUp_Load(object sender, EventArgs e)
    {
        _parent.MidiManager.PlaybackPaused = true;
        RefreshAll();
    }

    private void RefreshButton_Click(object sender, EventArgs e)
    {
        RefreshAll();
        var objectItem = (ComboBoxDeviceItem)boxSelector.SelectedItem!;
        boxDevice.Text = objectItem.MidiId;
    }
    private void comboBoxValueChange(object sender, EventArgs e)
    {
        _canDataBeUpdated = false;
        var objectItem = (ComboBoxDeviceItem)boxSelector.SelectedItem!;
        groupBox1.Enabled = objectItem.Id != -1;
        if (objectItem.Id == -1)
        {
            txtName.Text = string.Empty;
            boxDevice.SelectedIndex = -1;
            boxType.SelectedIndex = -1;
        }
        else
        {
            txtName.Text = objectItem.Name;
            boxDevice.Text = objectItem.MidiId;
            boxType.SelectedIndex = (int)objectItem.MidiDeviceType;
        }
        _canDataBeUpdated = true;
    }

    private void RefreshAll()
    {
        boxDevice.Items.Clear();
        boxDevice.Items.AddRange(_parent.MidiManager.GetAllDevices());
    }

    private void btnPlus_Click(object sender, EventArgs e)
    {
        var nuId = Random.Shared.Next();
        boxSelector.Items.Add(new ComboBoxDeviceItem("New Device", nuId, string.Empty, MidiDeviceType.GenericKeyboard, false));
        boxSelector.SelectedIndex = boxSelector.Items.Count - 1;
    }

    private void btnMinus_Click(object sender, EventArgs e)
    {
        var item = (ComboBoxDeviceItem)boxSelector.SelectedItem!;
        if (item.Id != -1)
        {
            boxSelector.Items.Remove(item);
        }
    }

    private void txtName_TextChanged(object sender, EventArgs e)
    {
        if (!_canDataBeUpdated) return;
        var item = (ComboBoxDeviceItem)boxSelector.SelectedItem!;
        item.Name = txtName.Text;
        boxSelector.Refresh();
    }

    private void boxDevice_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!_canDataBeUpdated) return;
        var item = (ComboBoxDeviceItem)boxSelector.SelectedItem!;
        item.MidiId = boxDevice.Text;
    }

    private void boxType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!_canDataBeUpdated) return;
        var item = (ComboBoxDeviceItem)boxSelector.SelectedItem!;
        item.MidiDeviceType = (MidiDeviceType)boxType.SelectedIndex;
    }

    private async void btnTest_Click(object sender, EventArgs e)
    {
        if (boxDevice.Text == string.Empty) return;
        btnTest.Enabled = false;
        await _parent.MidiManager.PlayTestTone(boxDevice.Text);
        btnTest.Enabled = true;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void MIDISetUp_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (DialogResult != DialogResult.OK) return;

        _parent.Database.Devices.Clear();
        foreach (var item in boxSelector.Items)
        {
            var objectItem = (ComboBoxDeviceItem)item;
            if (objectItem.Id != -1)
            {
                _parent.Database.Devices.Add(objectItem.Id, new MidiDevice(objectItem.Name, objectItem.MidiId, objectItem.IsRemote, objectItem.MidiDeviceType));
            }
        }
    }

    private class ComboBoxDeviceItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MidiId { get; set; }
        public MidiDeviceType MidiDeviceType { get; set; }
        public bool IsRemote { get; set; }
        public ComboBoxDeviceItem(string name, int id, string midiId, MidiDeviceType midiDeviceType, bool isRemote)
        {
            Name = name;
            Id = id;
            MidiId = midiId;
            MidiDeviceType = midiDeviceType;
            IsRemote = isRemote;
        }
        public override string ToString() => Name;
    }
}