using System;
using Melanchall.DryWetMidi.Core;

namespace CremeWorks.App.Midi;

/// <summary>
/// An opened MIDI input port. Events are raised on a background thread of the backend.
/// Closing the port is asynchronous, so it has to be disposed with <c>await using</c> or <see cref="IAsyncDisposable.DisposeAsync"/>.
/// </summary>
public interface IMidiInputPort : IAsyncDisposable
{
    string Name { get; }

    event Action<MidiEvent>? EventReceived;
}
