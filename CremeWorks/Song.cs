namespace CremeWorks
{
    public class Song
    {
        public string Title;
        public string Artist;
        public string Notes;
        public string Lyrics;
        public bool[][] InstrumentMap = { new bool[] { true, false, false, false }, new bool[] { false, true, false, false }, new bool[] { false, false, true, false }, new bool[] { false, false, false, true } };
    }
}
