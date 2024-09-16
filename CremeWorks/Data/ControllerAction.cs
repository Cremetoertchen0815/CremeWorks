using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;

namespace CremeWorks.App.Data;

public record ControllerAction(MidiEventType SourceEventType, FourBitNumber SourceEventChannel, byte SourceEventValue, ControllerActionType Action, int? Argument = null);

public enum ControllerActionType
{
    Undefined = -1,
    PrevSong = 0,
    NextSong,
    ScrollUp,
    ScrollDown,
    CueBack,
    CueAdvance,
    SoloMode,
    MuteMode,
    ReconnectMidi,
    MidiPanic,
    ToggleClick,
    PlayStopSample
}