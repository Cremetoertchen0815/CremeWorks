namespace CremeWorks.App.Data;

public record struct PlaylistEntryCommonInfo(int Index, string Header, string Title, string Artist, string Key, string Lyrics, string Instructions, byte Tempo, List<CueInstance> Cues)
{
    public readonly static PlaylistEntryCommonInfo None = new(-1, "None", "-", "-", "-", "", "", 120, []);
}
