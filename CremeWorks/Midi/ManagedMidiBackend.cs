using Commons.Music.Midi;
using Melanchall.DryWetMidi.Core;
using MidiEvent = Melanchall.DryWetMidi.Core.MidiEvent;

namespace CremeWorks.App.Midi;

/// <summary>
/// MIDI backend based on managed-midi, which talks to WinMM on Windows, CoreMIDI on macOS and ALSA on Linux.
/// </summary>
public class ManagedMidiBackend : IMidiBackend
{
#pragma warning disable CS0618 // MidiAccessManager still hands out the IMidiAccess interface
    private static IMidiAccess? _access;

    /// <summary>
    /// Error that occured while initialising the platform MIDI access, if there was any.
    /// On Linux this is usually a missing ALSA library (libasound2).
    /// </summary>
    public static string? InitializationError { get; private set; }

    private static IMidiAccess Access
    {
        get
        {
            if (_access is not null) return _access;
            try
            {
                _access = MidiAccessManager.Default;
                InitializationError = null;
            }
            catch (Exception ex)
            {
                InitializationError = (ex.InnerException ?? ex).Message;
                _access = MidiAccessManager.Empty;
            }
            return _access;
        }
    }
#pragma warning restore CS0618

    public string[] GetInputDeviceNames() => Access.Inputs.Select(x => x.Name).ToArray();

    public string[] GetOutputDeviceNames() => Access.Outputs.Select(x => x.Name).ToArray();

    public async Task<IMidiInputPort> OpenInputAsync(string name)
    {
        var details = Access.Inputs.FirstOrDefault(x => x.Name == name) ?? throw new InvalidOperationException(NotFoundMessage("input", name));
        return new ManagedMidiInputPort(name, await Access.OpenInputAsync(details.Id).ConfigureAwait(false));
    }

    public async Task<IMidiOutputPort> OpenOutputAsync(string name)
    {
        var details = Access.Outputs.FirstOrDefault(x => x.Name == name) ?? throw new InvalidOperationException(NotFoundMessage("output", name));
        return new ManagedMidiOutputPort(name, await Access.OpenOutputAsync(details.Id).ConfigureAwait(false));
    }

    private static string NotFoundMessage(string direction, string name) =>
        InitializationError is null
            ? $"MIDI {direction} device \"{name}\" was not found!"
            : $"MIDI {direction} device \"{name}\" was not found - the system MIDI service could not be started: {InitializationError}";

    private static async ValueTask ClosePortAsync(IMidiPort port)
    {
        try
        {
            await port.CloseAsync().ConfigureAwait(false);
        }
        catch (Exception)
        {
            //The device might already be gone, nothing we can do about it
        }
    }

    private sealed class ManagedMidiInputPort : IMidiInputPort
    {
        private readonly IMidiInput _port;
        private readonly BytesToMidiEventConverter _converter = new();

        public ManagedMidiInputPort(string name, IMidiInput port)
        {
            Name = name;
            _port = port;
            _port.MessageReceived += HandleMessage;
        }

        public string Name { get; }

        public event Action<MidiEvent>? EventReceived;

        private void HandleMessage(object? sender, MidiReceivedEventArgs e)
        {
            var handler = EventReceived;
            if (handler is null || e.Data is null || e.Length <= 0) return;

            List<MidiEvent> events;
            lock (_converter)
            {
                events = MidiWireFormat.FromBytes(e.Data, e.Start, e.Length, _converter);
            }
            foreach (var evnt in events) handler(evnt);
        }

        public ValueTask DisposeAsync()
        {
            _port.MessageReceived -= HandleMessage;
            EventReceived = null;
            return ClosePortAsync(_port);
        }
    }

    private sealed class ManagedMidiOutputPort(string name, IMidiOutput port) : IMidiOutputPort
    {
        private readonly MidiEventToBytesConverter _converter = new();
        private bool _isClosed;

        public string Name { get; } = name;

        public void SendEvent(MidiEvent e)
        {
            if (_isClosed) return;
            
            try
            {
                lock (_converter)
                {
                    var bytes = MidiWireFormat.ToBytes(e, _converter);
                    port.Send(bytes, 0, bytes.Length, 0);
                }
            }
            catch
            {
                _isClosed = true;
            }
        }

        public ValueTask DisposeAsync() => ClosePortAsync(port);
    }
}
