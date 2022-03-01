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
using static CremeWorks.SysExMan;

namespace CremeWorks
{
    public partial class ACEditor : Form
    {

        public Concert _c;
        public MIDIDevice _d;
        private bool _wasListening;

        private RefaceSystemData _datSys;
        private RefaceCPVoiceData _datCP;

        public ACEditor(Concert c, MIDIDevice d)
        {
            InitializeComponent();
            _c = c;
            _d = d;
            UpdateControls();

            //Set up MIDI shit
            _c.Connect();
            _wasListening = _d.Input.IsListeningForEvents;
            if (!_d.Input.IsListeningForEvents) _d.Input.StartEventsListening();
            _d.Input.EventReceived += ListenForSysEx;

        }

        private void UpdateControls()
        {
            typeSelector.SelectedIndex = (int)_d.Type;
        }

        private void ListenForSysEx(object sender, MidiEventReceivedEventArgs e)
        {
            if (e.Event.EventType != MidiEventType.NormalSysEx) return;

            var ev = (NormalSysExEvent)e.Event;
            if (ev.Data.Length == 44)
            {
                //System settings bulk received
                _datSys = StructMarshal<RefaceSystemData>.fromBytes(CutOffBulkDumpHeader(ev.Data));
            } else if (ev.Data.Length == 28 && _d.Type == DeviceType.RefaceCP)
            {
                //CP voice data bulk received
                _datCP = StructMarshal<RefaceCPVoiceData>.fromBytes(CutOffBulkDumpHeader(ev.Data));
            }
        }

        private byte[] CutOffBulkDumpHeader(byte[] dat)
        {
            byte[] res = new byte[dat.Length - 12];
            for (int i = 0; i < res.Length; i++) res[i] = dat[i + 10];
            return res;
        }

        private void button4_Click(object sender, EventArgs e) => SendSystemBulkdumpRequest(_d.Output, _d.Type);
        private void typeSelector_SelectedIndexChanged(object sender, EventArgs e) => _d.Type = (DeviceType)typeSelector.SelectedIndex;

        private void button1_Click(object sender, EventArgs e) => SendVoiceBulkdumpRequest(_d.Output, _d.Type);
    }
}
