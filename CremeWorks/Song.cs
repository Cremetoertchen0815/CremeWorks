﻿using System.Collections.Generic;

namespace CremeWorks
{
    public class Song
    {
        public string Title = string.Empty;
        public string Artist = string.Empty;
        public string Key = string.Empty;
        public string Lyrics = string.Empty;
        public string Instructions = string.Empty;
        public byte Tempo = 120;
        public bool Click = false;
        public bool SpecialEvent = false;
        public bool[][] NotePatchMap = { new bool[] { true, false, false, false, false, false }, new bool[] { false, true, false, false, false, false }, new bool[] { false, false, true, false, false, false }, new bool[] { false, false, false, true, false, false }, new bool[] { false, false, false, false, true, false }, new bool[] { false, false, false, false, false, true } };
        public bool[][] CCPatchMap = { new bool[] { true, false, false, false, false, false }, new bool[] { false, true, false, false, false, false }, new bool[] { false, false, true, false, false, false }, new bool[] { false, false, false, true, false, false }, new bool[] { false, false, false, false, true, false }, new bool[] { false, false, false, false, false, true } };
        public (bool Enabled, Reface.IRefacePatch Patch)[] AutoPatchSlots = { (false, null), (false, null), (false, null), (false, null), (false, null), (false, null) };
        public List<(ulong ID, string comment)> CueQueue = new List<(ulong, string)>(); //Cue list for managing light show
        public int ChordMacroSrc = 0;
        public int ChordMacroDst = 0;
        public List<(string Name, int TriggerNote, int Velocity, List<int> PlayNotes)> ChordMacros = new List<(string Name, int TriggerNote, int Velocity, List<int> PlayNotes)>();

        public Song Clone()
        {
            var nu = (Song)MemberwiseClone();
            nu.NotePatchMap = new bool[NotePatchMap.Length][];
            nu.CCPatchMap = new bool[CCPatchMap.Length][];
            nu.AutoPatchSlots = new (bool, Reface.IRefacePatch)[AutoPatchSlots.Length];
            nu.CueQueue = new List<(ulong, string)>();
            for (int i = 0; i < NotePatchMap.Length; i++) nu.NotePatchMap[i] = (bool[])NotePatchMap[i].Clone();
            for (int i = 0; i < CCPatchMap.Length; i++) nu.CCPatchMap[i] = (bool[])CCPatchMap[i].Clone();
            for (int i = 0; i < nu.AutoPatchSlots.Length; i++) nu.AutoPatchSlots[i] = (AutoPatchSlots[i].Enabled, AutoPatchSlots[i].Patch?.Clone());
            nu.CueQueue.AddRange(CueQueue);


            return nu;
        }
    }
}
