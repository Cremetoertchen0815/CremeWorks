﻿namespace CremeWorks.Client.Networking;

public record struct PlaylistEntryCommonInfo(int Index, string Header, string Title, string Artist, string Key, string Lyrics, string Instructions, byte Tempo, CueInstance[] Cues)
{
    public readonly static PlaylistEntryCommonInfo None = new(-1, "None", "-", "-", "-", "", "", 120, []);
}