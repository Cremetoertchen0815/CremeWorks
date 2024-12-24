using System.Text;

namespace CremeWorks.App.Data;

public class Playlist
{
    public List<IPlaylistEntry> Elements { get; init; } = [];
    public string Name { get; set; } = string.Empty;
    public DateOnly Date { get; set; }

    public string ToCsv(Database db)
    {
        //Build content
        var contentBuilder = new StringBuilder();
        int nr = 1;
        int secondsSum = 0;

        contentBuilder.AppendLine("Nr;Title;Artist;Duration;Tempo;Key;Id");
        foreach (var item in Elements)
        {
            string resultStr = ";;;;;;";
            switch (item)
            {
                case SongPlaylistEntry se:
                    if (!db.Songs.TryGetValue(se.SongId, out var song)) break;
                    var duration = TimeSpan.FromSeconds(song.ExpectedDurationSeconds);
                    secondsSum += song.ExpectedDurationSeconds;

                    resultStr = $"{nr++:00}.;{song.Title};{song.Artist};{duration:mm\\:ss};{song.Tempo} BPM;{song.Key};{se.SongId}";
                    break;
                case MarkerPlaylistEntry me:
                    resultStr = $"-;{me.Text};;;;;";
                    break;
            }
            contentBuilder.AppendLine(resultStr);
        }
        contentBuilder.AppendLine();
        contentBuilder.AppendLine($";;;{TimeSpan.FromSeconds(secondsSum):hh\\:mm\\:ss};;;");

        return contentBuilder.ToString();
    }
}