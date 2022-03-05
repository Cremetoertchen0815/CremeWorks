namespace CremeWorks
{
    public class Song
    {
        public string Title;
        public string Artist;
        public string Key;
        public string Lyrics;
        public bool[][] NoteMap = { new bool[] { true, false, false, false }, new bool[] { false, true, false, false }, new bool[] { false, false, true, false }, new bool[] { false, false, false, true } };
        public bool[][] CCMap = { new bool[] { true, false, false, false }, new bool[] { false, true, false, false }, new bool[] { false, false, true, false }, new bool[] { false, false, false, true } };
        public (bool Enabled, Reface.IRefacePatch Patch)[] AutoPatchSlots = { (false, null), (false, null), (false, null), (false, null) };
        public sbyte[] QA = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

        public Song Clone()
        {
            var nu = (Song)MemberwiseClone();
            nu.NoteMap = new bool[NoteMap.Length][];
            nu.CCMap = new bool[CCMap.Length][];
            nu.AutoPatchSlots = new (bool, Reface.IRefacePatch)[AutoPatchSlots.Length];
            for (var i = 0; i < NoteMap.Length; i++) nu.NoteMap[i] = (bool[])NoteMap[i].Clone();
            for (var i = 0; i < CCMap.Length; i++) nu.CCMap[i] = (bool[])CCMap[i].Clone();
            for (var i = 0; i < nu.AutoPatchSlots.Length; i++) nu.AutoPatchSlots[i] = (AutoPatchSlots[i].Enabled, AutoPatchSlots[i].Patch?.Clone());
            return nu;
        }
    }
}
