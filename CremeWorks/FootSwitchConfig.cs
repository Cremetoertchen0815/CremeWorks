using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CremeWorks
{
    public partial class FootSwitchConfig : Form
    {
        private (ComboBox, NumericUpDown, NumericUpDown, Button)[] _cont;
        private Concert _c;
        public FootSwitchConfig(Concert c)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            _c = c;
            c.Connect();

            _cont = new (ComboBox, NumericUpDown, NumericUpDown, Button)[] { (type1, valA1, valB1, det1), (type2, valA2, valB2, det2), (type3, valA3, valB3, det3),
                                                                             (type4, valA4, valB4, det4), (type5, valA5, valB5, det5), (type6, valA6, valB6, det6),
                                                                             (type7, valA7, valB7, det7), (type8, valA8, valB8, det8), (type9, valA9, valB9, det9), (type10, valA10, valB10, det10)};
        }

        private bool _InTest = false;
        private int _scanID;
        private void det1_Click(object sender, EventArgs e)
        {
            if (_InTest) return;

            //Grad data
            var btn = (Button)sender;
            _scanID = int.Parse((string)btn.Tag);
            var dev = _c.Devices[0].Input;
            if (dev == null) return;
            _InTest = true;
            btn.Text = "Sensing...";

            //Enable testing
            dev.StartEventsListening();
            dev.EventReceived += ScanSub;
        }

        private void ScanSub(object sender, MidiEventReceivedEventArgs e)
        {
            if (e.Event.EventType != MidiEventType.NoteOn && e.Event.EventType != MidiEventType.ControlChange) return;

            //Disable tetsing
            var scon = (InputDevice)sender;
            scon.EventReceived -= ScanSub;
            scon.StopEventsListening();
            _InTest = false;

            //Process data
            var controls = _cont[_scanID];
            if(e.Event.EventType == MidiEventType.NoteOn)
            {
                var ev = (NoteOnEvent)e.Event;
                controls.Item1.SelectedIndex = 0;
                controls.Item2.Value = ev.NoteNumber;
                controls.Item3.Value = ev.Velocity;
            } else if (e.Event.EventType == MidiEventType.ControlChange)
            {
                var ev = (ControlChangeEvent)e.Event;
                controls.Item1.SelectedIndex = 1;
                controls.Item2.Value = ev.ControlNumber;
                controls.Item3.Value = ev.ControlValue;
            }
            controls.Item4.Text = "Detect";
        }
    }
}
