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
    public List<MidiMatrixNode> MidiMatrixOverrides { get; } = [];
    public List<PatchInstance> Patches { get; } = [];
    public List<CueInstance> CueQueue { get; } = []; //Cue list for managing light show
    public List<ChordMacro> ChordMacros { get; } = [];
    public int ChordMacroSourceDeviceId { get; set; } = 0;
    public int ChordMacroDestinationDeviceId { get; set; } = 0;
}
