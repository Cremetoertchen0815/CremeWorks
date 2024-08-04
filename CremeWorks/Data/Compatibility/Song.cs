namespace CremeWorks.App.Data.Compatibility;

public class Song
{
    public string Title = string.Empty;
    public string Artist = string.Empty;
    public string Key = string.Empty;
    public string Lyrics = string.Empty;
    public string Instructions = string.Empty;
    public byte Tempo = 120;
    public bool Click = false;
    public bool SpecialEvent = false;
    public bool[][] NotePatchMap = [[true, false, false, false, false, false], [false, true, false, false, false, false], [false, false, true, false, false, false], [false, false, false, true, false, false], [false, false, false, false, true, false], [false, false, false, false, false, true]];
    public bool[][] CCPatchMap = [[true, false, false, false, false, false], [false, true, false, false, false, false], [false, false, true, false, false, false], [false, false, false, true, false, false], [false, false, false, false, true, false], [false, false, false, false, false, true]];
    public (bool Enabled, Reface.IRefacePatch? Patch)[] AutoPatchSlots = [(false, null), (false, null), (false, null), (false, null), (false, null), (false, null)];
    public List<(ulong ID, string comment)> CueQueue = []; //Cue list for managing light show
    public int ChordMacroSrc = 0;
    public int ChordMacroDst = 0;
    public List<ChordMacro> ChordMacros = [];
}