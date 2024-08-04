using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CremeWorks.App.Data;
public class MIDIManager
{
    public event Action<bool>? ConnectionChanged;

    public void Connect()
    {
        for (int i = 0; i < Devices.Length; i++)
        {
            var element = Devices[i];
            if (element.Name == null || element.Name == string.Empty) continue;
            try
            {
                if (element.Input == null && i != 1) element.Input = InputDevice.GetByName(element.Name);
            }
            catch { MessageBox.Show("Input Device \"" + element.Name + "\" not found! Check connections and reconnect!", "MIDI Connection error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            try
            {
                if (element.Output == null && i != 0) element.Output = OutputDevice.GetByName(element.Name);
            }
            catch { MessageBox.Show("Output Device \"" + element.Name + "\" not found! Check connections and reconnect!", "MIDI Connection error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        ConnectionChanged?.Invoke(true);
    }

    public void Disconnect()
    {
        Unregister();
        foreach (var element in Devices)
        {
            if (element.Name == null || element.Name == string.Empty) continue;
            if (element.Input != null) { element.Input.Dispose(); element.Input = null; }
            if (element.Output != null) { element.Output.Dispose(); element.Output = null; }
        }

        ConnectionChanged?.Invoke(false);
    }

    private readonly Concert _c;
    private readonly Action<MidiEvent> _lightingSendDelegate;
    private bool _reg = false;

    public Action<int, bool?> ActionExecute = (a, b) => { return; };
    public Song ActiveSong;

    public const int INSTR_DEVICE_OFFSET = 1;

    public void Register()
    {
        if (_reg) return;
        if (_c?.MIDIDevices[0]?.Input != null) _c.MIDIDevices[0].Input.EventReceived += ListenFootPedal;
        if (_c?.MIDIDevices[1]?.Input != null) _c.MIDIDevices[1].Input.EventReceived += ListenMaster;
        if (_c?.MIDIDevices[2]?.Input != null) _c.MIDIDevices[2].Input.EventReceived += ListenAux1;
        if (_c?.MIDIDevices[3]?.Input != null) _c.MIDIDevices[3].Input.EventReceived += ListenAux2;
        if (_c?.MIDIDevices[4]?.Input != null) _c.MIDIDevices[4].Input.EventReceived += ListenAux3;
        if (_c?.MIDIDevices[5]?.Input != null) _c.MIDIDevices[5].Input.EventReceived += ListenAux4;
        if (_c?.MIDIDevices[6]?.Input != null) _c.MIDIDevices[6].Input.EventReceived += ListenAux5;
        foreach (var element in _c.MIDIDevices) element.Input?.StartEventsListening();
        _reg = true;
    }

    public void Unregister()
    {
        if (!_reg) return;
        if (_c?.MIDIDevices[0]?.Input != null) _c.MIDIDevices[0].Input.EventReceived -= ListenFootPedal;
        if (_c?.MIDIDevices[1]?.Input != null) _c.MIDIDevices[1].Input.EventReceived -= ListenMaster;
        if (_c?.MIDIDevices[2]?.Input != null) _c.MIDIDevices[2].Input.EventReceived -= ListenAux1;
        if (_c?.MIDIDevices[3]?.Input != null) _c.MIDIDevices[3].Input.EventReceived -= ListenAux2;
        if (_c?.MIDIDevices[4]?.Input != null) _c.MIDIDevices[4].Input.EventReceived -= ListenAux3;
        if (_c?.MIDIDevices[5]?.Input != null) _c.MIDIDevices[5].Input.EventReceived -= ListenAux4;
        if (_c?.MIDIDevices[6]?.Input != null) _c.MIDIDevices[6].Input.EventReceived -= ListenAux5;
        foreach (var element in _c.MIDIDevices) element.Input?.StopEventsListening();
        _reg = false;
    }

    private void ListenFootPedal(object sender, MidiEventReceivedEventArgs e)
    {

        //If it isn't, redirect to lighting board
        if (e.Event.EventType == MidiEventType.NoteOff || e.Event.EventType == MidiEventType.ActiveSensing) return;
        _lightingSendDelegate(e.Event);

        //Check if foot pedal event is a macro
        for (int i = 0; i < _c.FootSwitchConfig.Length; i++)
        {
            if (e.Event.EventType == MidiEventType.NoteOn && _c.FootSwitchConfig[i].Item1 == MidiEventType.NoteOn)
            {
                var ev = (NoteOnEvent)e.Event;
                if (ev.NoteNumber == _c.FootSwitchConfig[i].Item2 && ev.Channel == _c.FootSwitchConfig[i].Item3)
                {
                    ActionExecute(i, ev.Velocity > 0);
                    return;
                }
            }
            else if (e.Event.EventType == MidiEventType.NoteOff && _c.FootSwitchConfig[i].Item1 == MidiEventType.NoteOn)
            {
                var ev = (NoteOffEvent)e.Event;
                if (ev.NoteNumber == _c.FootSwitchConfig[i].Item2 && ev.Channel == _c.FootSwitchConfig[i].Item3)
                {
                    ActionExecute(i, false);
                    return;
                }
            }
            else if (e.Event.EventType == MidiEventType.ControlChange && _c.FootSwitchConfig[i].Item1 == MidiEventType.ControlChange)
            {
                var ev = (ControlChangeEvent)e.Event;
                if (ev.ControlNumber == _c.FootSwitchConfig[i].Item2 && ev.Channel == _c.FootSwitchConfig[i].Item3)
                {
                    ActionExecute(i, ev.ControlValue >= 64);
                    return;
                }
            }
            else if (e.Event.EventType == MidiEventType.ProgramChange && _c.FootSwitchConfig[i].Item1 == MidiEventType.ProgramChange)
            {
                var ev = (ProgramChangeEvent)e.Event;
                if (ev.ProgramNumber == _c.FootSwitchConfig[i].Item2 && ev.Channel == _c.FootSwitchConfig[i].Item3)
                {
                    ActionExecute(i, null);
                    return;
                }
            }
        }
    }

    private void ListenMaster(object sender, MidiEventReceivedEventArgs e) => SendInstrData(0, e.Event);
    private void ListenAux1(object sender, MidiEventReceivedEventArgs e) => SendInstrData(1, e.Event);
    private void ListenAux2(object sender, MidiEventReceivedEventArgs e) => SendInstrData(2, e.Event);
    private void ListenAux3(object sender, MidiEventReceivedEventArgs e) => SendInstrData(3, e.Event);
    private void ListenAux4(object sender, MidiEventReceivedEventArgs e) => SendInstrData(4, e.Event);
    private void ListenAux5(object sender, MidiEventReceivedEventArgs e) => SendInstrData(5, e.Event);
    private void SendInstrData(int sender, MidiEvent e)
    {
        if (ActiveSong is null) return;

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
                    var dstDev = _c.MIDIDevices[ActiveSong.ChordMacroDst + INSTR_DEVICE_OFFSET].Output;
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
            for (int i = 0; i < 6; i++) if (ActiveSong.NotePatchMap[sender][i]) _c.MIDIDevices[INSTR_DEVICE_OFFSET + i].Output?.SendEvent(e);
        }
        else if (e.EventType == MidiEventType.ControlChange)
        {
            for (int i = 0; i < 6; i++) if (ActiveSong.CCPatchMap[sender][i]) _c.MIDIDevices[INSTR_DEVICE_OFFSET + i].Output?.SendEvent(e);
        }
    }
}
