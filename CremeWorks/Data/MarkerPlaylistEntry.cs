﻿namespace CremeWorks.App.Data;

public record MarkerPlaylistEntry : IPlaylistEntry
{
    public string Text { get; set; } = string.Empty;
    public string Instructions { get; set; } = string.Empty;
    public List<CueInstance> cueInstances { get; init; } = [];
    public PlaylistEntryCommonInfo GetCommonInformation(Database db, int? indexInPlaylist = null) => new PlaylistEntryCommonInfo($"---{Text}---", Text, string.Empty, string.Empty, string.Empty, Instructions, 0, cueInstances);
}