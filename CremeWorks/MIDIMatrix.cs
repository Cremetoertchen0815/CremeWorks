using Melanchall.DryWetMidi.Multimedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CremeWorks
{
    public class MIDIMatrix
    {

        private Concert _c;
        public MIDIMatrix(Concert c) => _c = c;
        private bool _reg = false;

        public void Register()
        {
            if (_reg) return;
            if (_c?.Devices[0]?.Output != null) _c.Devices[0].Output.EventSent += ListenFootPedal;
            if (_c?.Devices[1]?.Output != null) _c.Devices[1].Output.EventSent += ListenLightController;
            if (_c?.Devices[2]?.Output != null) _c.Devices[2].Output.EventSent += ListenMaster;
            if (_c?.Devices[3]?.Output != null) _c.Devices[3].Output.EventSent += ListenAux1;
            if (_c?.Devices[4]?.Output != null) _c.Devices[4].Output.EventSent += ListenAux2;
            if (_c?.Devices[5]?.Output != null) _c.Devices[5].Output.EventSent += ListenAux3;
            _reg = true;
        }

        public void Unregister()
        {
            if (!_reg) return;
            if (_c?.Devices[0]?.Output != null) _c.Devices[0].Output.EventSent -= ListenFootPedal;
            if (_c?.Devices[1]?.Output != null) _c.Devices[1].Output.EventSent -= ListenLightController;
            if (_c?.Devices[2]?.Output != null) _c.Devices[2].Output.EventSent -= ListenMaster;
            if (_c?.Devices[3]?.Output != null) _c.Devices[3].Output.EventSent -= ListenAux1;
            if (_c?.Devices[4]?.Output != null) _c.Devices[4].Output.EventSent -= ListenAux2;
            if (_c?.Devices[5]?.Output != null) _c.Devices[5].Output.EventSent -= ListenAux3;
        }

        private void ListenFootPedal(object sender, MidiEventSentEventArgs e )
        {

        }
        private void ListenLightController(object sender, MidiEventSentEventArgs e)
        {

        }
        private void ListenMaster(object sender, MidiEventSentEventArgs e)
        {

        }
        private void ListenAux1(object sender, MidiEventSentEventArgs e)
        {

        }
        private void ListenAux2(object sender, MidiEventSentEventArgs e)
        {

        }
        private void ListenAux3(object sender, MidiEventSentEventArgs e)
        {

        }
    }

}