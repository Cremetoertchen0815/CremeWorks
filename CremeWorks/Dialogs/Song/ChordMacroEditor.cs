using CremeWorks.App;
using CremeWorks.App.Data;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;

namespace CremeWorks.App.Dialogs
{
    public partial class ChordMacroEditor : Form
    {
        private IDataParent _parent;
        private Song _s;
        private bool _inTest = false;
        private bool _disconnectAfterTest = false;
        private bool _ignoreMacroListSelChange = true;
        private bool _ignoreMacroListValChange = false;
        public ChordMacroEditor(IDataParent parent, Song s)
        {
            _parent = parent;
            _s = s;
            InitializeComponent();
        }

        private void ChordMacroEditor_Load(object sender, EventArgs e)
        {
            valSrcDev.SelectedIndex = Math.Max(_s.ChordMacroSourceDeviceId - 2, 0);
            valDstDev.SelectedIndex = Math.Max(_s.ChordMacroDestinationDeviceId - 2, 0);
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
            var nuElement = new ChordMacro(valItemName.Text, (int)valItemTrigger.Value, (int)valItemVelocity.Value, lstItemNotes.Items.Cast<int>().ToList());
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
            //var dev = _c.MIDIDevices?[_s.ChordMacroSrc + 2].Input;
            //if (_inTest || dev == null) return;

            //_inTest = true;
            //btnItemTriggerCapture.Text = "Sensing...";
            //valSrcDev.Enabled = false;

            //_disconnectAfterTest = !dev.IsListeningForEvents;
            //if (_disconnectAfterTest) dev.StartEventsListening();
            //dev.EventReceived += TriggerCapture;
        }


        private void TriggerCapture(object sender, MidiEventReceivedEventArgs e)
        {
            if (e.Event.EventType != MidiEventType.NoteOn) return;

            //Disable capture
            var scon = (InputDevice)sender;
            scon.EventReceived -= TriggerCapture;
            if (_disconnectAfterTest) scon.StopEventsListening();
            _inTest = false;

            //Process data
            var note = (e.Event as NoteOnEvent);
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
            //var dev = _c.MIDIDevices?[_s.ChordMacroDestinationDeviceId].Input;
            //if (_inTest || dev == null) return;

            //_inTest = true;
            //btnItemNoteCapture.Text = "Press Sustain to capture";
            //valDstDev.Enabled = false;
            //_activeSenseKeys.Clear();

            //_disconnectAfterTest = !dev.IsListeningForEvents;
            //if (_disconnectAfterTest) dev.StartEventsListening();
            //dev.EventReceived += NoteCapture;
        }

        private List<int> _activeSenseKeys = new List<int>();
        private void NoteCapture(object sender, MidiEventReceivedEventArgs e)
        {
            //Capture key presses
            if (e.Event.EventType == MidiEventType.NoteOn)
            {
                _activeSenseKeys.Add(((NoteOnEvent)e.Event).NoteNumber);
                return;
            }
            else if (e.Event.EventType == MidiEventType.NoteOff)
            {
                var noteVal = (e.Event as NoteOnEvent).NoteNumber;
                if (_activeSenseKeys.Contains(noteVal)) _activeSenseKeys.Remove(noteVal);
                return;
            }
            else if (e.Event.EventType != MidiEventType.ControlChange)
                return;

            var ctrl = (e.Event as ControlChangeEvent);
            if (ctrl.ControlNumber != 64 || ctrl.ControlValue < 64) return;

            //Disable capture
            var scon = (InputDevice)sender;
            scon.EventReceived -= NoteCapture;
            if (_disconnectAfterTest) scon.StopEventsListening();
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
    }
}
