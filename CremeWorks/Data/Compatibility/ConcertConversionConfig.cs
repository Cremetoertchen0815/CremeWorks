namespace CremeWorks.App.Data.Compatibility;

public record struct ConcertConversionConfig(
    bool ImportActions,
    bool CreatePlaylist,
    int?[] SongRemapIds, // Special events are not included in this list! Because of that the index of the song in the list is not the same as the index in the playlist.
    DefaultRoutingConversionType DefaultRoutingConversionMethod,
    SongImportDoubleHandling SongImportDoubleHandling,
    PatchImportDoubleHandling PatchImportDoubleHandling
    );

public enum DefaultRoutingConversionType
{
    LeaveAsIs,
    GenerateLoopbackForNewDevices,
    CalculateRoutingFromMajority,
}

public enum SongImportDoubleHandling
{
    KeepBoth,
    KeepOld,
    KeepNew
}

public enum PatchImportDoubleHandling
{
    KeepBoth,
    Unify
}