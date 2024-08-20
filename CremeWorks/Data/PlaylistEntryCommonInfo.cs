namespace CremeWorks.App.Data;

public record struct PlaylistEntryCommonInfo(string Header, string Title, string Artist, string Key, string Lyrics, string Instructions, byte Tempo, IEnumerable<CueInstance> Cues);
