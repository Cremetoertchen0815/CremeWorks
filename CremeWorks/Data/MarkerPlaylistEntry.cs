namespace CremeWorks.App.Data;

public record MarkerPlaylistEntry(string Text, string Instructions) : IPlaylistEntry
{
    public string Heading => $"---{Text}---";
    public bool CountsAsSong => false;

    public string Title => Text;
    public string Artist => "-";
    public string Key => "-";
    public string Lyrics => string.Empty;
    public byte Tempo => 0;
}