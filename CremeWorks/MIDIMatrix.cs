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
            if (_c?.Devices[0]?.Output != null) _c.Devices[0].Input.EventReceived += ListenFootPedal;
            if (_c?.Devices[1]?.Output != null) _c.Devices[1].Input.EventReceived += ListenLightController;
            if (_c?.Devices[2]?.Output != null) _c.Devices[2].Input.EventReceived += ListenMaster;
            if (_c?.Devices[3]?.Output != null) _c.Devices[3].Input.EventReceived += ListenAux1;
            if (_c?.Devices[4]?.Output != null) _c.Devices[4].Input.EventReceived += ListenAux2;
            if (_c?.Devices[5]?.Output != null) _c.Devices[5].Input.EventReceived += ListenAux3;
            foreach (var element in _c.Devices) element.Input?.StartEventsListening();
            _reg = true;
        }

        public void Unregister()
        {
            if (!_reg) return;
            if (_c?.Devices[0]?.Output != null) _c.Devices[0].Input.EventReceived -= ListenFootPedal;
            if (_c?.Devices[1]?.Output != null) _c.Devices[1].Input.EventReceived -= ListenLightController;
            if (_c?.Devices[2]?.Output != null) _c.Devices[2].Input.EventReceived -= ListenMaster;
            if (_c?.Devices[3]?.Output != null) _c.Devices[3].Input.EventReceived -= ListenAux1;
            if (_c?.Devices[4]?.Output != null) _c.Devices[4].Input.EventReceived -= ListenAux2;
            if (_c?.Devices[5]?.Output != null) _c.Devices[5].Input.EventReceived -= ListenAux3;
            foreach (var element in _c.Devices) element.Input?.StopEventsListening();
            _reg = false;
        }

        private void ListenFootPedal(object sender, MidiEventReceivedEventArgs e )
        {
            Console.WriteLine("s");
        }
        private void ListenLightController(object sender, MidiEventReceivedEventArgs e)
        {
            Console.WriteLine("s");
        }
        private void ListenMaster(object sender, MidiEventReceivedEventArgs e)
        {
            Console.WriteLine("s");
        }
        private void ListenAux1(object sender, MidiEventReceivedEventArgs e)
        {
            Console.WriteLine("s");
        }
        private void ListenAux2(object sender, MidiEventReceivedEventArgs e)
        {
            Console.WriteLine("s");
        }
        private void ListenAux3(object sender, MidiEventReceivedEventArgs e)
        {
            Console.WriteLine("s");
        }
    }

}