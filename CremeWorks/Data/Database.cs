using System.Xml.Serialization;

namespace CremeWorks.App.Data;

public class Database
{
    [XmlIgnore]
    public string? FilePath { get; set; } = null;
    public int? CloudId { get; set; } = null;
    public DateTime LastSaved { get; set; } = DateTime.UtcNow;
    public Dictionary<int, MidiDevice> Devices { get; } = [];
    public Dictionary<int, IDevicePatch> Patches { get; } = [];
    public Dictionary<int, LightingCueItem> LightingCues { get; } = [];
    public List<ControllerAction> Actions { get; } = [];
    public Dictionary<int, Song> Songs { get; } = [];
    public List<Playlist> Playlists { get; } = [];
    public List<MidiMatrixNode> DefaultRouting { get; } = [];
    public SoloModeConfiguration SoloModeConfig { get; } = new();
}