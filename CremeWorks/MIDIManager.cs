using CremeWorks.App.Data;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using static CremeWorks.App.Reface.CommonHelpers;

namespace CremeWorks.App;
public class MidiManager
{
    public event Action<bool>? ConnectionChanged;

    private Dictionary<int, InternalMidiDevice> _midiDevices = [];
    private int[]? _matrixIds = null;
    private bool[,]? _matrixNote = null;
    private bool[,]? _matrixCC = null;
    private int _macroDeviceSourceId = -1;
    private int _macroDeviceDestId = -1;
    private List<ChordMacro> _activeMacros = [];
    private readonly IDataParent _parent;

    public bool PlaybackPaused { get; set; } = false;
    public bool IsConnected { get; private set; } = false;

    public const int INSTR_DEVICE_OFFSET = 1;

    public MidiManager(IDataParent parent) => _parent = parent;

    public void Connect()
    {
        if (IsConnected) return;

        _midiDevices.Clear();
        _matrixIds = new int[_parent.Database.Devices.Count(x => x.Value.IsInstrument && x.Value.Name != "")];
        _matrixNote = new bool[_matrixIds.Length, _matrixIds.Length];
        _matrixCC = new bool[_matrixIds.Length, _matrixIds.Length];

        int i = 0;
        foreach (var item in _parent.Database.Devices)
        {
            var currentIndex = i;
            if (item.Value.Name is "" || item.Value.Type == MidiDeviceType.Unknown) continue;
            if (item.Value.IsInstrument) _matrixIds[i++] = item.Key;

            InputDevice? inputDev = null;
            OutputDevice? outputDev = null;
            try
            {
                //Connect to input device and start listening
                if (item.Value.IsInstrument || item.Value.Type is MidiDeviceType.GenericController)
                {
                    inputDev = InputDevice.GetByName(item.Value.Name);
                    inputDev.EventReceived += item.Value.IsInstrument ? (sender, e) => ListenInstrument(currentIndex, e.Event) : ListenFootPedal;
                    inputDev.StartEventsListening();
                }
                //Connect to output device
                if (item.Value.IsInstrument || item.Value.Type is MidiDeviceType.Lighting)
                {
                    outputDev = OutputDevice.GetByName(item.Value.Name);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect to \"" + item.Value.Name + "\"! Check connections and reconnect!", "MIDI Connection error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                inputDev?.StopEventsListening();
                inputDev?.Dispose();
                inputDev = null;
                outputDev?.Dispose();
                outputDev = null;
            }

            _midiDevices.Add(item.Key, new InternalMidiDevice(item.Value.MidiId, inputDev, outputDev));
        }

        IsConnected = true;
        ConnectionChanged?.Invoke(true);
    }

    public void Disconnect()
    {
        if (!IsConnected) return;
        foreach (var element in _midiDevices.Values)
        {
            if (element.Input != null) element.Input.Dispose();
            if (element.Output != null) element.Output.Dispose();
        }
        _midiDevices.Clear();

        IsConnected = false;
        ConnectionChanged?.Invoke(false);
    }

    public async Task PlayTestTone(string deviceId)
    {
        var play_dev = _midiDevices.Where(x => x.Value.MidiName == deviceId).Select(x => x.Value.Output).FirstOrDefault();
        if (play_dev == null) return;

        play_dev.SendEvent(new NoteOnEvent(new SevenBitNumber(84), new SevenBitNumber(80)));
        await Task.Delay(200);
        play_dev.SendEvent(new NoteOffEvent(new SevenBitNumber(84), new SevenBitNumber(80)));
    }

    public Task SendNoteToLighting(byte noteValue) => Task.CompletedTask;

    public string[] GetAllDevices()
    {
        var wasConnected = IsConnected;
        Disconnect();
        var outList = OutputDevice.GetAll();
        var inList = InputDevice.GetAll();
        var outNames = outList.Select(x => x.Name).ToArray();
        var inNames = inList.Select(x => x.Name).ToArray();
        foreach (var el in outList) el.Dispose();
        foreach (var el in inList) el.Dispose();

        if (wasConnected) Connect();
        return [.. outNames, .. inNames];
    }

    public Task SendAllNotesOff() => Task.WhenAll(_midiDevices.Select(item => Task.Run(() => item.Value.Output?.TurnAllNotesOff())));

    public void UpdateMatrix()
    {
        MidiMatrixNode[]? nodes = _parent.CurrentEntry is SongPlaylistEntry se ? [.. _parent.Database.DefaultRouting, .. _parent.Database.Songs[se.SongId].RoutingOverrides] : null;
        if (nodes == null || _matrixIds == null)
        {
            _matrixNote = null;
            _matrixCC = null;
            return;
        }

        _matrixNote = new bool[_matrixIds.Length, _matrixIds.Length];
        _matrixCC = new bool[_matrixIds.Length, _matrixIds.Length];

        //Update matrix information
        foreach (var node in nodes)
        {
            var sourceIdx = Array.IndexOf(_matrixIds, node.SourceDeviceId);
            var destIdx = Array.IndexOf(_matrixIds, node.DestinationDeviceId);
            if (sourceIdx < 0 || destIdx < 0) continue;
            if (sourceIdx >= _matrixIds.Length || destIdx >= _matrixIds.Length) continue;

            var prevNoteOn = _matrixNote[sourceIdx, destIdx];
            _matrixNote[sourceIdx, destIdx] = (node.Type & MidiMatrixNodeType.Notes) == MidiMatrixNodeType.Notes;
            _matrixCC[sourceIdx, destIdx] = (node.Type & MidiMatrixNodeType.ControlChange) == MidiMatrixNodeType.ControlChange;

            //If the matrix has turn off a connection, send all notes off to the destination
            if (prevNoteOn && !_matrixNote[sourceIdx, destIdx]) Task.Run(() => _midiDevices[_matrixIds[destIdx]]?.Output?.TurnAllNotesOff());
        }

        //Update macro information
        var song = _parent.Database.Songs[((SongPlaylistEntry)_parent.CurrentEntry!).SongId];
        _macroDeviceSourceId = song.ChordMacroSourceDeviceId;
        _macroDeviceDestId = song.ChordMacroDestinationDeviceId;
        _activeMacros = song.ChordMacros;

        //Apply patches to instruments
        foreach (var item in song.Patches)
        {
            if (!_parent.Database.Patches.TryGetValue(item.PatchId, out var patch)) continue;
            patch.ApplyPatch(_parent, item.DeviceId);
        }
    }


    public bool TryGetMidiDevicePort(int deviceId, out InputDevice? input, out OutputDevice? output)
    {
        if (_midiDevices.TryGetValue(deviceId, out var dev) && dev.Input is not null && dev.Output is not null)
        {
            input = dev.Input;
            output = dev.Output;
            return true;
        }
        input = null;
        output = null;
        return false;
    }

    private void ListenFootPedal(object? sender, MidiEventReceivedEventArgs e)
    {
        //If it isn't, redirect to lighting board
        if (PlaybackPaused || e.Event.EventType == MidiEventType.NoteOff || e.Event.EventType == MidiEventType.ActiveSensing) return;
        //_lightingSendDelegate(e.Event);

        //Check if foot pedal event is a macro
        foreach (var action in _parent.Database.Actions)
        {
            if (action.SourceEventType != e.Event.EventType) continue;
            switch (e.Event.EventType)
            {
                case MidiEventType.NoteOn:
                    var note = (NoteOnEvent)e.Event;
                    if (note.NoteNumber == action.SourceEventValue && note.Channel == action.SourceEventChannel)
                    {
                        _parent.ExecuteAction(action.Action, note.Velocity > 0);
                        return;
                    }
                    break;
                case MidiEventType.ControlChange:
                    var cc = (ControlChangeEvent)e.Event;
                    if (cc.ControlNumber == action.SourceEventValue && cc.Channel == action.SourceEventChannel)
                    {
                        _parent.ExecuteAction(action.Action, cc.ControlValue >= 64);
                        return;
                    }
                    break;
                case MidiEventType.ProgramChange:
                    var pc = (ProgramChangeEvent)e.Event;
                    if (pc.ProgramNumber == action.SourceEventValue && pc.Channel == action.SourceEventChannel)
                    {
                        _parent.ExecuteAction(action.Action, null);
                        return;
                    }
                    break;
            }
        }
    }

    private void ListenInstrument(int index, MidiEvent e)
    {
        if (PlaybackPaused || _matrixIds is null || _matrixNote is null || _matrixCC is null || e.EventType is MidiEventType.TimingClock or MidiEventType.ActiveSensing) return;

        if (e.EventType is MidiEventType.NoteOn or MidiEventType.NoteOff && _matrixIds[index] == _macroDeviceSourceId)
        {
            //Check for chord macros
            var note = (NoteEvent)e;
            for (int i = 0; i < _activeMacros.Count; i++)
            {
                var macro = _activeMacros[i];
                if (macro.TriggerNote != note.NoteNumber || _macroDeviceDestId <= 0) continue;
                var dstDev = _midiDevices[_macroDeviceDestId].Output;
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
        for (int i = 0; i < _matrixIds.Length; i++)
        {
            if (_matrixNote[index, i] && e.EventType is MidiEventType.NoteOn or MidiEventType.NoteOff ||
                _matrixCC[index, i] && e.EventType is MidiEventType.ControlChange)
            {
                _midiDevices[_matrixIds[i]].Output?.SendEvent(e);
            }
        }
    }

    private record InternalMidiDevice(string MidiName, InputDevice? Input, OutputDevice? Output);
}
