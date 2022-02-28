using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using System;

namespace CremeWorks
{
    public class MIDIMatrix
    {

        private Concert _c;
        public MIDIMatrix(Concert c) => _c = c;
        private bool _reg = false;

        public bool[][] KeyMap = { new bool[] { false, false, false, false }, new bool[] { false, false, false, false }, new bool[] { false, false, false, false }, new bool[] { false, false, false, false } };

        public void Register()
        {
            if (_reg) return;
            if (_c?.Devices[0]?.Input != null) _c.Devices[0].Input.EventReceived += ListenFootPedal;
            if (_c?.Devices[1]?.Input != null) _c.Devices[1].Input.EventReceived += ListenLightController;
            if (_c?.Devices[2]?.Input != null) _c.Devices[2].Input.EventReceived += ListenMaster;
            if (_c?.Devices[3]?.Input != null) _c.Devices[3].Input.EventReceived += ListenAux1;
            if (_c?.Devices[4]?.Input != null) _c.Devices[4].Input.EventReceived += ListenAux2;
            if (_c?.Devices[5]?.Input != null) _c.Devices[5].Input.EventReceived += ListenAux3;
            foreach (var element in _c.Devices) element.Input?.StartEventsListening();
            _reg = true;
        }

        public void Unregister()
        {
            if (!_reg) return;
            if (_c?.Devices[0]?.Input != null) _c.Devices[0].Input.EventReceived -= ListenFootPedal;
            if (_c?.Devices[1]?.Input != null) _c.Devices[1].Input.EventReceived -= ListenLightController;
            if (_c?.Devices[2]?.Input != null) _c.Devices[2].Input.EventReceived -= ListenMaster;
            if (_c?.Devices[3]?.Input != null) _c.Devices[3].Input.EventReceived -= ListenAux1;
            if (_c?.Devices[4]?.Input != null) _c.Devices[4].Input.EventReceived -= ListenAux2;
            if (_c?.Devices[5]?.Input != null) _c.Devices[5].Input.EventReceived -= ListenAux3;
            foreach (var element in _c.Devices) element.Input?.StopEventsListening();
            _reg = false;
        }

        private void ListenFootPedal(object sender, MidiEventReceivedEventArgs e )
        {
            for (int i = 0; i < _c.FootSwitchConfig.Length; i++)
            {
                //Check if event matches mask
                if (e.Event.EventType == _c.FootSwitchConfig[i].Item1)
                {
                    if (e.Event.EventType == MidiEventType.NoteOn)
                    {
                        var ev = (NoteOnEvent)e.Event;
                        if (ev.NoteNumber != _c.FootSwitchConfig[i].Item2 || ev.Channel != _c.FootSwitchConfig[i].Item3) continue;
                    } else
                    {
                        var ev = (ControlChangeEvent)e.Event;
                        if (ev.ControlNumber != _c.FootSwitchConfig[i].Item2 || ev.Channel != _c.FootSwitchConfig[i].Item3) continue;
                    }
                }

                //Execute action
                switch (i)
                {
                    default:
                        break;
                }
            }
        }
        private void ListenLightController(object sender, MidiEventReceivedEventArgs e)
        {
            
        }

        private void ListenMaster(object sender, MidiEventReceivedEventArgs e)
        {
            for (int i = 0; i < 4; i++)
                if (KeyMap[0][i]) _c.Devices[2 + i].Output?.SendEvent(e.Event);
        }
        private void ListenAux1(object sender, MidiEventReceivedEventArgs e)
        {
            for (int i = 0; i < 4; i++)
                if (KeyMap[1][i]) _c.Devices[2 + i].Output?.SendEvent(e.Event);
        }
        private void ListenAux2(object sender, MidiEventReceivedEventArgs e)
        {
            for (int i = 0; i < 4; i++)
                if (KeyMap[2][i]) _c.Devices[2 + i].Output?.SendEvent(e.Event);
        }
        private void ListenAux3(object sender, MidiEventReceivedEventArgs e)
        {
            for (int i = 0; i < 4; i++)
                if (KeyMap[3][i]) _c.Devices[2 + i].Output?.SendEvent(e.Event);
        }
    }

}