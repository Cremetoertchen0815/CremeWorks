using CremeWorks.App;
using CremeWorks.App.Data;
using System.ComponentModel;

namespace CremeWorks;

public partial class MidiSetUp : Form
{

    private readonly IDataParent _parent;
    private bool _canDataBeUpdated = true;
    private readonly BindingList<ComboBoxDeviceItem> _comboBoxDeviceItems = [];

    public MidiSetUp(IDataParent parent)
    {
        InitializeComponent();
        _parent = parent;

        foreach (var item in _parent.Database.Devices)
        {
            _comboBoxDeviceItems.Add(new ComboBoxDeviceItem(item.Value.Name, item.Key, item.Value.MidiId, item.Value.Type, item.Value.IsRemoteSource));
        }
        boxSelector.DataSource = new BindingSource(_comboBoxDeviceItems, null);
    }

    private void MIDISetUp_Load(object sender, EventArgs e)
    {
        _parent.MidiManager.PlaybackPaused = true;
        RefreshAll();
    }

    private void RefreshButton_Click(object sender, EventArgs e)
    {
        RefreshAll();
        if (boxSelector.SelectedItem is not ComboBoxDeviceItem item) return;
        boxDevice.Text = item.MidiId;
    }
    private void comboBoxValueChange(object sender, EventArgs e)
    {
        _canDataBeUpdated = false;
        var objectItem = boxSelector.SelectedItem as ComboBoxDeviceItem;
        groupBox1.Enabled = objectItem is not null;
        if (objectItem is null)
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
        var item = new ComboBoxDeviceItem("New Device", nuId, string.Empty, MidiDeviceType.GenericKeyboard, false);
        _comboBoxDeviceItems.Add(item);
        boxSelector.Text = item.Name;
        boxSelector.SelectedItem = item;
        comboBoxValueChange(sender, e);
    }

    private void btnMinus_Click(object sender, EventArgs e)
    {
        if (boxSelector.SelectedItem is not ComboBoxDeviceItem item) return;
        _comboBoxDeviceItems.Remove(item);
        boxSelector.SelectedIndex = boxSelector.Items.Count - 1;
        if (boxSelector.SelectedIndex < 0)
        {
            boxSelector.Text = string.Empty;
            comboBoxValueChange(sender, e);
        }
    }

    private void txtName_TextChanged(object sender, EventArgs e)
    {
        if (!_canDataBeUpdated || boxSelector.SelectedItem is not ComboBoxDeviceItem item) return;
        item.Name = txtName.Text;
        _comboBoxDeviceItems.ResetItem(boxSelector.SelectedIndex);
    }

    private void boxDevice_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!_canDataBeUpdated || boxSelector.SelectedItem is not ComboBoxDeviceItem item) return;
        item.MidiId = boxDevice.Text;
    }

    private void boxType_SelectedIndexChanged(object sender, EventArgs e)
    {
        var item = boxSelector.SelectedItem as ComboBoxDeviceItem;
        if (!_canDataBeUpdated || item is null) return;
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
            if (objectItem.Id == -1) continue;
            _parent.Database.Devices.Add(objectItem.Id, new MidiDevice(objectItem.Name, objectItem.MidiId, objectItem.IsRemote, objectItem.MidiDeviceType));
        }
    }

    private class ComboBoxDeviceItem(string name, int id, string midiId, MidiDeviceType midiDeviceType, bool isRemote)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string MidiId { get; set; } = midiId;
        public MidiDeviceType MidiDeviceType { get; set; } = midiDeviceType;
        public bool IsRemote { get; set; } = isRemote;

        public override string ToString() => Name;
    }
}