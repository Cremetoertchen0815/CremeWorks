namespace CremeWorks.App.Data;

public class Playlist
{
    public List<IPlaylistEntry> Elements { get; set; } = [];
    public string Name { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
}