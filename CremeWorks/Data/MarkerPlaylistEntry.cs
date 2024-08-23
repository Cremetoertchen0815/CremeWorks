using System.Xml;

namespace CremeWorks.App.Data;

public class MarkerPlaylistEntry : IPlaylistEntry
{
    public string Text { get; set; } = string.Empty;
    public string Instructions { get; set; } = string.Empty;
    public List<CueInstance> Cues { get; init; } = [];

    public PlaylistEntryType Type => PlaylistEntryType.Marker;

    public PlaylistEntryCommonInfo GetCommonInformation(Database db, int? indexInPlaylist = null) => new PlaylistEntryCommonInfo($"---{Text}---", Text, string.Empty, string.Empty, string.Empty, Instructions, 0, Cues);

    public static MarkerPlaylistEntry Deserialize(XmlNode node)
    {
        var entry = new MarkerPlaylistEntry();
        entry.Text = node.Attributes?["text"]?.Value ?? throw new Exception("Marker entry without text");
        entry.Instructions = node.Attributes?["instructions"]?.Value ?? "";
        foreach (XmlNode cueNode in node.ChildNodes)
        {
            var cueId = int.Parse(cueNode.Attributes?["id"]?.Value ?? throw new Exception("Cue without Id"));
            var description = cueNode.Attributes?["description"]?.Value ?? "";
            entry.Cues.Add(new CueInstance(cueId, description));
        }
        return entry;
    }
}