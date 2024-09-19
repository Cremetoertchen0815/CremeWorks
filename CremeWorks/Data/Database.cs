using System.Xml.Serialization;

namespace CremeWorks.App.Data;

public class Database
{
    public string? FilePath { get; set; } = null;
    public int? CloudId { get; set; } = null;
    public DateTime? LastServerSync { get; set; } = null;
    public DateTime LastLocalSave { get; set; } = DateTime.UtcNow;

    //Data
    public Dictionary<int, MidiDevice> Devices { get; } = [];
    public Dictionary<int, IDevicePatch> Patches { get; } = [];
    public Dictionary<int, LightingCueItem> LightingCues { get; } = [];
    public List<ControllerAction> Actions { get; } = [];
    public Dictionary<int, Song> Songs { get; } = [];
    public List<Playlist> Playlists { get; } = [];
    public List<MidiMatrixNode> DefaultRouting { get; } = [];
    public SoloModeConfiguration SoloModeConfig { get; } = new();
}