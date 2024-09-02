using CremeWorks.App;
using CremeWorks.App.Data;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;

namespace CremeWorks
{
    public partial class FootSwitchConfig : Form
    {
        private readonly IDataParent _parent;

        private string GetEventType(MidiEventType type) => type switch
        {
            MidiEventType.NoteOn => "Note On",
            MidiEventType.ControlChange => "Control Change",
            MidiEventType.ProgramChange => "Program Change",
            _ => "Unknown"
        };

        private readonly string[] _actionNames = new string[]
        {
            "Prev Song",
            "Next Song",
            "Scroll Up",
            "Scroll Down",
            "Cue Back",
            "Cue Advance",
            "Solo Mode",
            "Mute Mode",
            "Reconnect MIDI",
            "Toggle Click",
            "Play/Stop Sample"
        };

        public FootSwitchConfig(IDataParent parent)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            _parent = parent;

            //Load combobox values
            boxType.Items.AddRange(["Note On", "Control Change", "Program Change"]);
            boxType.SelectedIndex = 0;
            boxAction.Items.AddRange(_actionNames);
            boxAction.SelectedIndex = 0;

            foreach (var item in parent.Database.Actions)
            {
                var listViewItem = new ListViewItem(_actionNames[(int)item.Action]);
                listViewItem.SubItems.Add(GetEventType(item.SourceEventType));
                listViewItem.SubItems.Add((item.SourceEventChannel + 1).ToString());
                listViewItem.SubItems.Add(item.SourceEventValue.ToString());
                listViewItem.Tag = item;
                lstActions.Items.Add(listViewItem);
            }
        }

        private bool _InTest = false;
        private void btnDetect_Click(object sender, EventArgs e)
        {
            if (_InTest) return;
            if (!_parent.MidiManager.IsConnected)
            {
                MessageBox.Show("MIDI devices are not connected. Please connect to use the detect function!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Grad data
            _parent.MidiManager.ControllerEventReceived += ScanSub;
            _InTest = true;
            btnDetect.Text = "Sensing...";
        }

        private void ScanSub(MidiEvent evnt)
        {
            if (evnt.EventType != MidiEventType.NoteOn && evnt.EventType != MidiEventType.ControlChange && evnt.EventType != MidiEventType.ProgramChange) return;

            //Disable tetsing
            _parent.MidiManager.ControllerEventReceived -= ScanSub;
            _InTest = false;
            btnDetect.Text = "Detect";

            //Process data
            if (evnt.EventType == MidiEventType.NoteOn)
            {
                var ev = (NoteOnEvent)evnt;
                boxType.SelectedIndex = 0;
                nbrNumber.Value = ev.NoteNumber;
                nbrChannel.Value = ev.Channel + 1;
            }
            else if (evnt.EventType == MidiEventType.ControlChange)
            {
                var ev = (ControlChangeEvent)evnt;
                boxType.SelectedIndex = 1;
                nbrNumber.Value = ev.ControlNumber;
                nbrChannel.Value = ev.Channel + 1;
            }
            else if (evnt.EventType == MidiEventType.ProgramChange)
            {
                var ev = (ProgramChangeEvent)evnt;
                boxType.SelectedIndex = 2;
                nbrNumber.Value = ev.ProgramNumber;
                nbrChannel.Value = ev.Channel + 1;
            }
        }

        private void FootSwitchConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_InTest)
            {
                _parent.MidiManager.ControllerEventReceived -= ScanSub;
                _InTest = false;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstActions.SelectedItems.Count == 0) return;
            var item = (ControllerAction)lstActions.SelectedItems[0].Tag!;
            lstActions.Items.Remove(lstActions.SelectedItems[0]);
            _parent.Database.Actions.Remove(item);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var eventType = boxType.SelectedIndex switch
            {
                0 => MidiEventType.NoteOn,
                1 => MidiEventType.ControlChange,
                2 => MidiEventType.ProgramChange,
                _ => MidiEventType.UnknownMeta
            };
            var channel = new FourBitNumber((byte)(nbrChannel.Value - 1));
            var value = (byte)nbrNumber.Value;
            var action = (ControllerActionType)boxAction.SelectedIndex;
            var item = new ControllerAction(eventType, channel, value, action);

            if (_parent.Database.Actions.Any(x => x.SourceEventType == eventType && x.SourceEventChannel == channel && x.SourceEventValue == value))
            {
                MessageBox.Show("There's already an action defined for these MIDI settings!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var listViewItem = new ListViewItem(_actionNames[(int)item.Action]);
            listViewItem.SubItems.Add(GetEventType(item.SourceEventType));
            listViewItem.SubItems.Add(item.SourceEventChannel.ToString());
            listViewItem.SubItems.Add(item.SourceEventValue.ToString());
            listViewItem.Tag = item;
            lstActions.Items.Add(listViewItem);
            _parent.Database.Actions.Add(item);
        }
    }
}
