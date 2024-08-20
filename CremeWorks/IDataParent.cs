using CremeWorks.App.Data;

namespace CremeWorks.App;

public interface IDataParent
{
    Database Database { get; }
    MidiManager MidiManager { get; }
    void ExecuteAction(ControllerActionType type, bool? enable);
    IPlaylistEntry? CurrentEntry { get; }
}