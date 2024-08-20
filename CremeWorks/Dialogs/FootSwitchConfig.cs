using CremeWorks.App;
using Melanchall.DryWetMidi.Core;

namespace CremeWorks
{
    public partial class FootSwitchConfig : Form
    {
        private readonly IDataParent _parent;
        private const int PARAM_COUNT = 6;

        public FootSwitchConfig(IDataParent parent)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            _parent = parent;

            ////Load data into dialogue
            //for (int i = 0; i < PARAM_COUNT; i++)
            //{
            //    var cfg = _c.FootSwitchConfig[i];
            //    var cnt = _cont[i];
            //    cnt.Item1.SelectedIndex = MidiEventTypeToIndex(cfg.Item1);
            //    cnt.Item2.Value = cfg.Item2;
            //    cnt.Item3.Value = Math.Max((int)cfg.Item3, 1);
            //}
        }

        //private bool _InTest = false;
        //private int _scanID;
        //private void det1_Click(object sender, EventArgs e)
        //{
        //    if (_InTest) return;

        //    //Grad data
        //    var btn = (Button)sender;
        //    _scanID = int.Parse((string)btn.Tag);
        //    var dev = _c.MIDIDevices[0].Input;
        //    if (dev == null) return;
        //    _InTest = true;
        //    btn.Text = "Sensing...";

        //    //Enable testing
        //    var hasListened = dev.IsListeningForEvents;
        //    dev.EventReceived += ScanSub;
        //    if (!hasListened) dev.StartEventsListening();
        //}

        //private void ScanSub(object sender, MidiEventReceivedEventArgs e)
        //{
        //    if (e.Event.EventType != MidiEventType.NoteOn && e.Event.EventType != MidiEventType.ControlChange && e.Event.EventType != MidiEventType.ProgramChange) return;

        //    //Disable tetsing
        //    var scon = (InputDevice)sender;
        //    scon.EventReceived -= ScanSub;
        //    scon.StopEventsListening();
        //    _InTest = false;

        //    //Process data
        //    var controls = _cont[_scanID];
        //    if (e.Event.EventType == MidiEventType.NoteOn)
        //    {
        //        var ev = (NoteOnEvent)e.Event;
        //        controls.Item1.SelectedIndex = 0;
        //        controls.Item2.Value = ev.NoteNumber;
        //        controls.Item3.Value = ev.Channel + 1;
        //    }
        //    else if (e.Event.EventType == MidiEventType.ControlChange)
        //    {
        //        var ev = (ControlChangeEvent)e.Event;
        //        controls.Item1.SelectedIndex = 1;
        //        controls.Item2.Value = ev.ControlNumber;
        //        controls.Item3.Value = ev.Channel + 1;
        //    }
        //    else if (e.Event.EventType == MidiEventType.ProgramChange)
        //    {
        //        var ev = (ProgramChangeEvent)e.Event;
        //        controls.Item1.SelectedIndex = 2;
        //        controls.Item2.Value = ev.ProgramNumber;
        //        controls.Item3.Value = ev.Channel + 1;
        //    }
        //    controls.Item4.Text = "Detect";
        //}

        private void FootSwitchConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            //var dev = _c.MIDIDevices[0].Input;
            //if (dev?.IsListeningForEvents == true) dev.StopEventsListening();

            ////Save data from dialogue
            //for (int i = 0; i < PARAM_COUNT; i++)
            //{
            //    var cnt = _cont[i];
            //    _c.FootSwitchConfig[i] = (IndexToMidiEventType(cnt.Item1.SelectedIndex), (short)cnt.Item2.Value, (byte)(cnt.Item3.Value - 1));
            //}

            //_c.MidiMatrix.Register();
        }

        private MidiEventType IndexToMidiEventType(int i)
        {
            switch (i)
            {
                case 0:
                    return MidiEventType.NoteOn;
                case 1:
                    return MidiEventType.ControlChange;
                case 2:
                    return MidiEventType.ProgramChange;
                default:
                    return MidiEventType.UnknownMeta;
            }
        }

        private int MidiEventTypeToIndex(MidiEventType i)
        {
            switch (i)
            {
                case MidiEventType.NoteOn:
                    return 0;
                case MidiEventType.ControlChange:
                    return 1;
                case MidiEventType.ProgramChange:
                    return 2;
                default:
                    return -1;
            }
        }
    }
}
