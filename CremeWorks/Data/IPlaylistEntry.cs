namespace CremeWorks.App.Data;

/// <summary>
/// Represents an entry in a playlist.
/// </summary>
public interface IPlaylistEntry
{
    /// <summary>
    /// The type of the entry.
    /// </summary>
    PlaylistEntryType Type { get; }

    /// <summary>
    /// Creates a deep copy of the entry.
    /// </summary>
    /// <returns></returns>
    IPlaylistEntry CreateCopy();

    /// <summary>
    /// Retrieves common display information from the entry(white is merely a reference) with the given database.
    /// </summary>
    /// <param name="db">The database from where the information should be retrieved.</param>
    /// <param name="index">The index of the element in the list.</param>
    /// <param name="numberInPlaylist">The number of the item(only exists for songs in a set)</param>
    PlaylistEntryCommonInfo GetCommonInformation(Database db, int index, int? numberInPlaylist);
}

public enum PlaylistEntryType
{
    Song,
    Marker
}