namespace CremeWorks.App.Data;

public interface IPlaylistEntry
{
    /// <summary>
    /// Retrieves common display information from the entry(white is merely a reference) with the given database.
    /// </summary>
    /// <param name="db">The database from where the information should be retrieved.</param>
    PlaylistEntryCommonInfo GetCommonInformation(Database db, int? indexInPlaylist = null);
}