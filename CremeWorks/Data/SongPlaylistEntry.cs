namespace CremeWorks.App.Data;

public record SongPlaylistEntry : IPlaylistEntry
{
    public int SongId { get; set; }

    public PlaylistEntryType Type => PlaylistEntryType.Song;

    public SongPlaylistEntry(int songId) => SongId = songId;

    public PlaylistEntryCommonInfo GetCommonInformation(Database db, int indexInPlaylist, bool isSet)
    {
        var song = db.Songs[SongId];
        var header = isSet ? $"{indexInPlaylist + 1}. {song.Title} - {song.Artist}" : $"{song.Artist} - {song.Title}";
        return new PlaylistEntryCommonInfo(indexInPlaylist, header, song.Title, song.Artist, song.Key, song.Lyrics, song.Instructions, song.Tempo, song.Cues);
    }
}
