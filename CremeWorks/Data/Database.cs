namespace CremeWorks.App.Data;

public class Database
{
    public string? FilePath { get; set; }
    public Dictionary<int, MidiDevice> Devices { get; } = [];
    public Dictionary<int, IDevicePatch> Patches { get; } = [];
    public List<LightingCueItem> LightingCues { get; } = [];
    public List<ControllerAction> Actions { get; } = [];
    public Dictionary<int, Song> Songs { get; } = [];
    public List<Playlist> Playlists { get; } = [];
    public List<MidiMatrixNode> DefaultRouting { get; } = [];
}