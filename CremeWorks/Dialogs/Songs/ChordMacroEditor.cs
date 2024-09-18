using CremeWorks.App;
using CremeWorks.App.Data;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;

namespace CremeWorks.App.Dialogs.Songs
{
    public partial class ChordMacroEditor : Form
    {
        private IDataParent _parent;
        private Song _s;
        private bool _inTest = false;
        private bool _ignoreMacroListSelChange = true;
        private bool _ignoreMacroListValChange = false;
        private List<int> _activeSenseKeys = [];
        public ChordMacroEditor(IDataParent parent, Song s)
        {
            _parent = parent;
            _s = s;
            InitializeComponent();
        }

        private void ChordMacroEditor_Load(object sender, EventArgs e)
        {
            //Add device list to comboboxes
            var devices = _parent.Database.Devices.Where(x => x.Value.IsInstrument)
                .Select(x => new DeviceComboboxItem(x.Key, x.Value.Name, x.Value.MidiId)).ToArray();
            valSrcDev.Items.AddRange(devices);
            valDstDev.Items.AddRange(devices);

            valSrcDev.SelectedItem = devices.FirstOrDefault(x => x.Id == _s.ChordMacroSourceDeviceId);
            valDstDev.SelectedItem = devices.FirstOrDefault(x => x.Id == _s.ChordMacroDestinationDeviceId);
            for (int i = 0; i < _s.ChordMacros.Count; i++) lstMacros.Items.Add(_s.ChordMacros[i].Name);
            if (_s.ChordMacros.Count > 0) lstMacros.SelectedIndex = 0;
            _ignoreMacroListSelChange = false;
        }

        private void Dev_SelectedIndexChanged(object sender, EventArgs e)
        {
            _s.ChordMacroSourceDeviceId = valSrcDev.SelectedIndex + 2;
            _s.ChordMacroDestinationDeviceId = valDstDev.SelectedIndex + 2;
        }

        private void btnMacrosAdd_Click(object sender, EventArgs e)
        {
            _ignoreMacroListSelChange = true;
            var nuElement = new ChordMacro("New Macro", (int)valItemTrigger.Value, (int)valItemVelocity.Value, lstItemNotes.Items.Cast<int>().ToList());
            _s.ChordMacros.Add(nuElement);
            lstMacros.Items.Add(nuElement.Name);
            _ignoreMacroListSelChange = false;

            lstMacros.SelectedIndex = lstMacros.Items.Count - 1;
        }

        private void lstMacros_SelectedIndexChanged(object sender, EventArgs e)
        {
            boxItem.Enabled = lstMacros.SelectedIndex >= 0;
            if (_ignoreMacroListSelChange || lstMacros.SelectedIndex < 0) return;

            var sel = _s.ChordMacros[lstMacros.SelectedIndex];
            valItemName.Text = sel.Name;
            valItemTrigger.Value = sel.TriggerNote;
            valItemVelocity.Value = sel.Velocity;

            lstItemNotes.Items.Clear();
            foreach (var n in sel.PlayNotes) lstItemNotes.Items.Add(n);
        }

        private void valItemName_TextChanged(object sender, EventArgs e)
        {
            if (_ignoreMacroListValChange) return;
            _ignoreMacroListSelChange = true;
            var sel = _s.ChordMacros[lstMacros.SelectedIndex];
            sel.Name = valItemName.Text;
            _s.ChordMacros[lstMacros.SelectedIndex] = sel;
            lstMacros.Items[lstMacros.SelectedIndex] = sel.Name;
            _ignoreMacroListSelChange = false;
            valItemName.Focus();
        }

        private void valItemTrigger_ValueChanged(object sender, EventArgs e)
        {
            if (_ignoreMacroListValChange) return;
            var sel = _s.ChordMacros[lstMacros.SelectedIndex];
            sel.TriggerNote = (int)valItemTrigger.Value;
            _s.ChordMacros[lstMacros.SelectedIndex] = sel;
        }

        private void valItemVelocity_ValueChanged(object sender, EventArgs e)
        {
            if (_ignoreMacroListValChange) return;
            var sel = _s.ChordMacros[lstMacros.SelectedIndex];
            sel.Velocity = (int)valItemVelocity.Value;
            _s.ChordMacros[lstMacros.SelectedIndex] = sel;
        }

        private void btnMacrosRem_Click(object sender, EventArgs e)
        {
            if (lstMacros.SelectedIndex < 0) return;
            _ignoreMacroListSelChange = true;
            var selIdx = lstMacros.SelectedIndex - 1;
            _s.ChordMacros.RemoveAt(lstMacros.SelectedIndex);
            lstMacros.Items.RemoveAt(lstMacros.SelectedIndex);
            _ignoreMacroListSelChange = false;
            lstMacros.SelectedIndex = selIdx;
        }

        private void btnItemRemNote_Click(object sender, EventArgs e)
        {
            if (lstItemNotes.SelectedIndex < 0) return;
            var sel = _s.ChordMacros[lstMacros.SelectedIndex];
            sel.PlayNotes.RemoveAt(lstItemNotes.SelectedIndex);
            lstItemNotes.Items.RemoveAt(lstItemNotes.SelectedIndex);
        }

        private void btnItemTriggerCapture_Click(object sender, EventArgs e)
        {
            if (_inTest || _s.ChordMacroSourceDeviceId < 1) return;

            if (!_parent.MidiManager.IsConnected)
            {
                MessageBox.Show("MIDI devices are not connected. Please connect to use the detect function!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!_parent.MidiManager.TryGetMidiDevicePort(_s.ChordMacroSourceDeviceId, out var inputDev, out _) || inputDev is null)
            {
                MessageBox.Show("Couldn't fetch destination device!", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _inTest = true;
            btnItemTriggerCapture.Text = "Sensing...";
            valSrcDev.Enabled = false;

            inputDev.EventReceived += TriggerCapture;
        }


        private void TriggerCapture(object? sender, MidiEventReceivedEventArgs e)
        {
            if (e.Event.EventType != MidiEventType.NoteOn) return;

            //Disable capture
            var scon = (InputDevice)sender!;
            scon.EventReceived -= TriggerCapture;
            //_inTest = false;

            //Process data
            var note = ((NoteOnEvent)e.Event);
            var sel = _s.ChordMacros[lstMacros.SelectedIndex];
            sel.TriggerNote = note.NoteNumber;
            sel.Velocity = note.Velocity;
            valItemTrigger.Value = sel.TriggerNote;
            valItemVelocity.Value = sel.Velocity;
            _s.ChordMacros[lstMacros.SelectedIndex] = sel;

            btnItemTriggerCapture.Text = "Detect";
            valSrcDev.Enabled = true;
        }

        private void btnItemNoteCapture_Click(object sender, EventArgs e)
        {
            if (_inTest || _s.ChordMacroDestinationDeviceId < 1) return;

            if (!_parent.MidiManager.IsConnected)
            {
                MessageBox.Show("MIDI devices are not connected. Please connect to use the detect function!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!_parent.MidiManager.TryGetMidiDevicePort(_s.ChordMacroDestinationDeviceId, out var inputDev, out _) || inputDev is null)
            {
                MessageBox.Show("Couldn't fetch destination device!", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _inTest = true;
            btnItemNoteCapture.Text = "Press Sustain to capture";
            valDstDev.Enabled = false;
            _activeSenseKeys.Clear();

            inputDev.EventReceived += NoteCapture;
        }

        private void NoteCapture(object? sender, MidiEventReceivedEventArgs e)
        {
            //Capture key presses
            if (e.Event.EventType == MidiEventType.NoteOn)
            {
                _activeSenseKeys.Add(((NoteOnEvent)e.Event).NoteNumber);
                return;
            }
            else if (e.Event.EventType == MidiEventType.NoteOff)
            {
                var noteVal = ((NoteOnEvent)e.Event).NoteNumber;
                if (_activeSenseKeys.Contains(noteVal)) _activeSenseKeys.Remove(noteVal);
                return;
            }
            else if (e.Event.EventType != MidiEventType.ControlChange)
                return;

            var ctrl = (ControlChangeEvent)e.Event;
            if (ctrl.ControlNumber != 64 || ctrl.ControlValue < 64) return;

            //Disable capture
            var scon = (InputDevice)sender!;
            scon.EventReceived -= NoteCapture;
            _inTest = false;

            //Process data
            var macro = _s.ChordMacros[lstMacros.SelectedIndex];
            macro.PlayNotes.Clear();
            lstItemNotes.Items.Clear();
            for (int i = 0; i < _activeSenseKeys.Count; i++)
            {
                macro.PlayNotes.Add(_activeSenseKeys[i]);
                lstItemNotes.Items.Add(_activeSenseKeys[i]);
            }

            btnItemNoteCapture.Text = "Detect Notes (on dst. device)";
            valDstDev.Enabled = true;
        }

        private void btnItemAddNote_Click(object sender, EventArgs e)
        {
            if (lstMacros.SelectedIndex < 0) return;
            var macro = _s.ChordMacros[lstMacros.SelectedIndex];
            if (ChordMacroAddNoteDialog.OpenDialog(macro.PlayNotes) is not int i) return;
            macro.PlayNotes.Add(i);
            lstItemNotes.Items.Add(i);
        }

        private record DeviceComboboxItem(int Id, string Name, string MidiId)
        {
            public override string ToString() => Name;
        }
    }
}
