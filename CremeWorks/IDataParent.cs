using CremeWorks.App.Data;

namespace CremeWorks.App;

public interface IDataParent
{
    Database Database { get; }
    MidiManager MidiManager { get; }
    void ExecuteAction(ActionType type, bool? enable);
}