namespace CremeWorks.App.Data;

public record SongPlaylistEntry : IPlaylistEntry
{
    //Content
    public int SongId { get; set; }

    //ctor
    public SongPlaylistEntry(int songId) => SongId = songId;

    //IPlaylistEntry
    public PlaylistEntryType Type => PlaylistEntryType.Song;

    public PlaylistEntryCommonInfo GetCommonInformation(Database db, int indexInPlaylist, bool isSet)
    {
        var song = db.Songs[SongId];
        var header = isSet ? $"{indexInPlaylist + 1}. {song.Title} - {song.Artist}" : $"{song.Artist} - {song.Title}";
        return new PlaylistEntryCommonInfo(indexInPlaylist, header, song.Title, song.Artist, song.Key, song.Lyrics, song.Instructions, song.Tempo, song.Cues);
    }

    public IPlaylistEntry CreateCopy() => new SongPlaylistEntry(SongId);
}
