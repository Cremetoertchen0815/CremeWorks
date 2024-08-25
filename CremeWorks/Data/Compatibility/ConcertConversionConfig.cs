namespace CremeWorks.App.Data.Compatibility;

public record struct ConcertConversionConfig(
    ConversionOverrideType SongOverride,
    bool ImportDevices,
    DefaultRoutingConversionType DefaultRoutingConversionMethod,
    bool ImportActions,
    int?[] SongRemapIds,
    SongImportDoubleHandling SongImportDoubleHandling,
    bool CreatePlaylist
    );

public enum ConversionOverrideType
{
    ImportIntoCurrent,
    CreateNew
}

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