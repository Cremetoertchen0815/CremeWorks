using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;

namespace CremeWorks.App.Data;

public record ControllerAction(MidiEventType SourceEventType, FourBitNumber SourceEventChannel, byte SourceEventValue, ControllerActionType Action, int? Argument = null);

public enum ControllerActionType
{
    NextSong,
    PrevSong,
    ScrollUp,
    ScrollDown,
    CueAdvance,
    CueBack,
    SoloMode,
    MuteMode,
    ReconnectMidi,
    ToggleClick,
    PlayStopSample
}