﻿namespace CremeWorks.Common.Networking
{
    public class SongInformation
    {
        public int Index { get; set; }
        public int Tempo { get; set; }
        public bool ClickActive { get; set; }
        public string Instructions { get; set; }
        public string[] Cues { get; set; }
    }
}
