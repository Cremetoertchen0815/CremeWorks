using System.Runtime.InteropServices;

namespace CremeWorks.Reface
{
    internal class CSPatch : IRefacePatch
    {
        public RefaceSystemData SystemSettings { get; set; }
        public RefaceCSVoiceData VoiceSettings { get; set; }
        public DeviceType Type => DeviceType.RefaceCS;

        public void ApplySettings(MIDIDevice d) => SysExMan.SendParameterChange(d?.Output, Type, new byte[] { 0, 0, 0 }, StructMarshal<RefaceSystemData>.getBytes(SystemSettings));
        public void ApplyPatch(MIDIDevice d) => SysExMan.SendParameterChange(d?.Output, Type, new byte[] { 0x30, 0, 0 }, StructMarshal<RefaceCSVoiceData>.getBytes(VoiceSettings));
        public IRefacePatch Clone() => (IRefacePatch)MemberwiseClone();

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RefaceCSVoiceData
        {
            public byte Volume;
            public byte Reserved1;
            public RefaceCSLFOAssign LFOAssign;
            public byte LFODepth;
            public byte LFOSpeed;
            public byte Portamento;
            public RefaceCSOSCType OSCType;
            public byte OSCTexture;
            public byte OSCMod;
            public byte FilterCutoff;
            public byte FilterResonance;
            public byte EGBalance;
            public byte EGAttack;
            public byte EGDecay;
            public byte EGSustain;
            public byte EGRelease;
            public RefaceCSFXType FXType;
            public byte FXDepth;
            public byte FXRate;
            public byte Reserved2;
            public short Reserved3;
        }

        public enum RefaceCSLFOAssign : byte { Off = 0, Amp = 1, Filter = 2, Pitch = 3, Oscillator = 4 }
        public enum RefaceCSOSCType : byte { Saw = 0, Pulse = 1, OscSync = 2, RingMod = 3, FM = 4 }
        public enum RefaceCSFXType : byte { Distortion = 0, ChorusFlanger = 1, Phaser = 2, Delay = 3, Thru = 4 }


    }
}
