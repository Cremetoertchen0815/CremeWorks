using CremeWorks.App.Data;

namespace CremeWorks.App;

public interface IDataParent
{
    Database Database { get; }
    MidiManager MidiManager { get; }
    SoloManager SoloManager { get; }
    IPlaylistEntry? CurrentEntry { get; }
}