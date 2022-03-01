using System.Runtime.InteropServices;

namespace CremeWorks.Reface
{

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RefaceSystemData
    {
        public byte MIDIChannelTransmit;
        public byte MIDIChannelReceive;
        public int MasterTune;
        public byte LocalControl;
        public byte MasterTranspose;
        public short Tempo;
        public byte LCDContrast;
        public byte SustainPedalSelect;
        public byte AutoPwrOff;
        public byte SpkOut;
        public byte MIDICtrl;
        public byte GlobalPBRange;
        public int Reserved2;
        public byte FootSwitchMode;
        public byte Reserved3;
        public short Reserved4;
        public int Reserved5;
        public int Reserved6;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RefaceCPVoiceData
    {
        byte Volume;
        byte Reserved1;
        RefaceCPWaveType WaveType;
        byte Drive;
        RefaceCPEffectA EffectAType;
        byte EffectADepth;
        byte EffectARate;
        RefaceCPEffectB EffectBType;
        byte EffectBDepth;
        byte EffectBSpeed;
        RefaceCPEffectC EffectCType;
        byte EffectCDepth;
        byte EffectCTime;
        byte ReverbDepth;
        short Reserved2;
    }


    public enum RefaceCPWaveType : byte { RdI = 0, RdII = 1, Wr = 2, Clv = 3, Toy = 4, CP = 5, Pno = 6 }
    public enum RefaceCPEffectA : byte { Thru = 0, Tremolo = 1, wah = 2 }
    public enum RefaceCPEffectB : byte { Thru = 0, Chorus = 1, Phaser = 2 }
    public enum RefaceCPEffectC : byte { Thru = 0, DDelay = 1, ADelay = 2 }
    public enum DeviceType { Undefined = 0, RefaceCS = 1, RefaceDX = 2, RefaceCP = 3 }
}
