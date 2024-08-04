using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CremeWorks.App.Data;
public record SongPlaylistEntry(int SongId) : IPlaylistEntry
{
    public string Heading => throw new NotImplementedException();
    public bool CountsAsSong => true;

    public string Title => throw new NotImplementedException();
    public string Artist => throw new NotImplementedException();
    public string Key => throw new NotImplementedException();
    public string Lyrics => throw new NotImplementedException();
    public string Instructions => throw new NotImplementedException();
    public byte Tempo => throw new NotImplementedException();
}
