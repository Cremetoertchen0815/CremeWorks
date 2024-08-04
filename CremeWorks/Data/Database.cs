namespace CremeWorks.App.Data;

public class Database
{
    public string? FilePath { get; set; }
    public Dictionary<int, MidiDevice> Devices { get; } = [];
    public Dictionary<int, Reface.IRefacePatch> Patches { get; } = [];
    public List<LightingCueItem> LightingCues { get; } = [];
    public List<ControllerAction> Actions { get; } = [];
    public Dictionary<int, Song> Songs { get; } = [];
    public List<Playlist> Playlists { get; } = [];
}