using Melanchall.DryWetMidi.Core;

namespace CremeWorks.App.Midi;

/// <summary>
/// An opened MIDI output port.
/// Closing the port is asynchronous, so it has to be disposed with <c>await using</c> or <see cref="IAsyncDisposable.DisposeAsync"/>.
/// </summary>
public interface IMidiOutputPort : IAsyncDisposable
{
    string Name { get; }

    /// <summary>
    /// Hands the event over to the driver. The underlying backends write the bytes without blocking,
    /// so this stays synchronous and can be called from a MIDI listening thread.
    /// </summary>
    void SendEvent(MidiEvent e);
}
