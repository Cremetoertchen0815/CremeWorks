using System.Runtime.InteropServices;

namespace CremeWorks.Reface
{
    class CPPatch : IRefacePatch
    {
        public RefaceSystemData SystemSettings { get; set; }
        public RefaceCPVoiceData VoiceSettings { get; set; }
        public DeviceType Type => DeviceType.RefaceCP;


        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RefaceCPVoiceData
        {
            public byte Volume;
            public byte Reserved1;
            public RefaceCPWaveType WaveType;
            public byte Drive;
            public RefaceCPEffectA EffectAType;
            public byte EffectADepth;
            public byte EffectARate;
            public RefaceCPEffectB EffectBType;
            public byte EffectBDepth;
            public byte EffectBSpeed;
            public RefaceCPEffectC EffectCType;
            public byte EffectCDepth;
            public byte EffectCTime;
            public byte ReverbDepth;
            public short Reserved2;
        }


        public enum RefaceCPWaveType : byte { RdI = 0, RdII = 1, Wr = 2, Clv = 3, Toy = 4, CP = 5, Pno = 6 }
        public enum RefaceCPEffectA : byte { Thru = 0, Tremolo = 1, Wah = 2 }
        public enum RefaceCPEffectB : byte { Thru = 0, Chorus = 1, Phaser = 2 }
        public enum RefaceCPEffectC : byte { Thru = 0, DDelay = 1, ADelay = 2 }

        public void ApplySettings(MIDIDevice d)
        {
            
        }

        public void ApplyPatch(MIDIDevice d)
        {
            
        }
    }
}
