namespace CremeWorks.App.Data;

public record SongPlaylistEntry(int SongId) : IPlaylistEntry
{
    public PlaylistEntryCommonInfo GetCommonInformation(Database db, int? indexInPlaylist = null)
    {
        var song = db.Songs[SongId];
        var header = indexInPlaylist.HasValue ? $"{indexInPlaylist.Value + 1}. {song.Title} - {song.Artist}" : $"{song.Artist} - {song.Title}";
        return new PlaylistEntryCommonInfo(header, song.Title, song.Artist, song.Key, song.Lyrics, song.Instructions, song.Tempo, song.Cues);
    }
}
