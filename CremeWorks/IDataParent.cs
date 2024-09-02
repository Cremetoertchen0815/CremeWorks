using CremeWorks.App.Data;

namespace CremeWorks.App;

public interface IDataParent
{
    Database Database { get; }
    MidiManager MidiManager { get; }
    IPlaylistEntry? CurrentEntry { get; }
}