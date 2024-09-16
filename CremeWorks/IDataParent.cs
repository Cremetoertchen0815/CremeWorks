using CremeWorks.App.Data;
using CremeWorks.Networking;

namespace CremeWorks.App;

public interface IDataParent
{
    Database Database { get; }
    MidiManager MidiManager { get; }
    VolumeManager SoloManager { get; }
    NetworkingServer NetworkManager { get; }
    IPlaylistEntry? CurrentEntry { get; }
}