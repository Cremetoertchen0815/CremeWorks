namespace CremeWorks.App.Data;

public class Song
{
    public string Title { get; set; } = "New Song";
    public string Artist { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public string Lyrics { get; set; } = string.Empty;
    public string Instructions { get; set; } = string.Empty;
    public byte Tempo { get; set; } = 120;
    public bool Click { get; set; } = false;
    public List<MidiMatrixNode> RoutingOverrides { get; } = [];
    public List<PatchInstance> Patches { get; } = [];
    public List<CueInstance> Cues { get; } = []; //Cue list for managing light show
    public List<ChordMacro> ChordMacros { get; } = [];
    public int ChordMacroSourceDeviceId { get; set; } = 0;
    public int ChordMacroDestinationDeviceId { get; set; } = 0;

    public Song Clone()
    {
        var s = new Song
        {
            Title = Title,
            Artist = Artist,
            Key = Key,
            Lyrics = Lyrics,
            Instructions = Instructions,
            Tempo = Tempo,
            Click = Click,
            ChordMacroSourceDeviceId = ChordMacroSourceDeviceId,
            ChordMacroDestinationDeviceId = ChordMacroDestinationDeviceId
        };
        foreach (var p in Patches) s.Patches.Add(p);
        foreach (var m in RoutingOverrides) s.RoutingOverrides.Add(m);
        foreach (var c in Cues) s.Cues.Add(c);
        foreach (var c in ChordMacros) s.ChordMacros.Add(c.Clone());
        return s;
    }
}
