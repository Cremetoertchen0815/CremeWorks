namespace CremeWorks.App.Data;

public record ControllerAction(ControllerActionEvent SourceEvent, byte Value, ControllerActionType Action, int Argument);

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

public enum ControllerActionEvent
{
    NoteOn,
    ControlChange,
    ProgramChange,
}