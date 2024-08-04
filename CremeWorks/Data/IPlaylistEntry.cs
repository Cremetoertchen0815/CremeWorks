namespace CremeWorks.App.Data;

public interface IPlaylistEntry
{
    string Heading { get; }
    bool CountsAsSong { get; }

    string Title { get; }
    string Artist { get; }
    string Key { get; }
    string Lyrics { get; }
    string Instructions { get; }
    byte Tempo { get; }
}