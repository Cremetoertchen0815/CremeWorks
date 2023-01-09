using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.MusicTheory;
using System;
using System.Runtime.InteropServices;

namespace CremeWorks
{
    public class MIDIMatrix
    {

        private readonly Concert _c;
        public MIDIMatrix(Concert c) => _c = c;
        private bool _reg = false;

        public Action<int, bool?> ActionExecute = (a, b) => { return; };
        public Song ActiveSong;
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

        private void ListenFootPedal(object sender, MidiEventReceivedEventArgs e)
        {

            for (int i = 0; i < _c.FootSwitchConfig.Length; i++)
            {
                if (e.Event.EventType == MidiEventType.NoteOn && _c.FootSwitchConfig[i].Item1 == MidiEventType.NoteOn)
                {
                    var ev = (NoteOnEvent)e.Event;
                    if (ev.NoteNumber == _c.FootSwitchConfig[i].Item2 && ev.Channel == _c.FootSwitchConfig[i].Item3)
                        ActionExecute(i, ev.Velocity > 0);
                }
                else if (e.Event.EventType == MidiEventType.NoteOff && _c.FootSwitchConfig[i].Item1 == MidiEventType.NoteOn)
                {
                    var ev = (NoteOffEvent)e.Event;
                    if (ev.NoteNumber == _c.FootSwitchConfig[i].Item2 && ev.Channel == _c.FootSwitchConfig[i].Item3)
                        ActionExecute(i, false);
                }
                else if (e.Event.EventType == MidiEventType.ControlChange && _c.FootSwitchConfig[i].Item1 == MidiEventType.ControlChange)
                {
                    var ev = (ControlChangeEvent)e.Event;
                    if (ev.ControlNumber == _c.FootSwitchConfig[i].Item2 && ev.Channel == _c.FootSwitchConfig[i].Item3)
                        ActionExecute(i, ev.ControlValue >= 64);
                }
                else if (e.Event.EventType == MidiEventType.ProgramChange && _c.FootSwitchConfig[i].Item1 == MidiEventType.ProgramChange)
                {
                    var ev = (ProgramChangeEvent)e.Event;
                    if (ev.ProgramNumber == _c.FootSwitchConfig[i].Item2 && ev.Channel == _c.FootSwitchConfig[i].Item3) ActionExecute(i, null);
                }
            }
        }

        private void ListenLightController(object sender, MidiEventReceivedEventArgs e)
        {
            if (e.Event.EventType == MidiEventType.ActiveSensing) return;
            System.Diagnostics.Debug.WriteLine(e.Event.EventType);
            var lel = (NormalSysExEvent)e.Event;
        }

        private void ListenMaster(object sender, MidiEventReceivedEventArgs e) => SendInstrData(0, e.Event);
        private void ListenAux1(object sender, MidiEventReceivedEventArgs e) => SendInstrData(1, e.Event);
        private void ListenAux2(object sender, MidiEventReceivedEventArgs e) => SendInstrData(2, e.Event);
        private void ListenAux3(object sender, MidiEventReceivedEventArgs e) => SendInstrData(3, e.Event);
        private void SendInstrData(int sender, MidiEvent e)
        {
            if (e.EventType == MidiEventType.NoteOn || e.EventType == MidiEventType.NoteOff)
            {
                //Check for chord macros
                if (sender == ActiveSong.ChordMacroSrc)
                {
                    var note = (NoteEvent)e;
                    for (int i = 0; i < ActiveSong.ChordMacros.Count; i++)
                    {
                        var macro = ActiveSong.ChordMacros[i];
                        if (macro.TriggerNote != note.NoteNumber || ActiveSong.ChordMacroDst < 0) continue;
                        var dstDev = _c.Devices[ActiveSong.ChordMacroDst + 2].Output;
                        if (dstDev == null) continue;

                        if (note.Velocity > 0) note.Velocity = new SevenBitNumber((byte)macro.Velocity);
                        for (int j = 0; j < macro.PlayNotes.Count; j++)
                        {
                            note.NoteNumber = new SevenBitNumber((byte)macro.PlayNotes[j]);
                            dstDev.SendEvent(note);
                        }
                        return;
                    }
                }
                
                //If no chord macro, simply forward
                for (int i = 0; i < 4; i++) if (ActiveSong.NotePatchMap[sender][i]) _c.Devices[2 + i].Output?.SendEvent(e);
            }
            else if (e.EventType == MidiEventType.ControlChange)
            {
                for (int i = 0; i < 4; i++) if (ActiveSong.CCPatchMap[sender][i]) _c.Devices[2 + i].Output?.SendEvent(e);
            }
        }
    }

}