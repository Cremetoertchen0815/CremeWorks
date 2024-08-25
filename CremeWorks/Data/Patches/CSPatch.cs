using System.Runtime.InteropServices;
using System.Xml;
using CremeWorks.App.Data;

namespace CremeWorks.App.Data.Patches
{
    public class CSPatch(string name) : IDevicePatch
    {
        public string Name { get; init; } = name;
        public MidiDeviceType DeviceType => MidiDeviceType.RefaceCS;
        public RefaceCSVoiceData VoiceSettings { get; set; }


        public IDevicePatch Clone() => (IDevicePatch)MemberwiseClone();
        public void ApplyPatch(int deviceId) => throw new NotImplementedException();
        public bool AreEqual(IDevicePatch? other) => other is CSPatch c && c.VoiceSettings == VoiceSettings;

        //public void ApplySettings(MIDIDevice d) => CommonHelpers.SendParameterChange(d?.Output, Type, new byte[] { 0, 0, 0 }, StructMarshal<RefaceSystemData>.getBytes(SystemSettings));
        //public void ApplyPatch(MIDIDevice d) => CommonHelpers.SendParameterChange(d?.Output, Type, new byte[] { 0x30, 0, 0 }, StructMarshal<RefaceCSVoiceData>.getBytes(VoiceSettings));

        public void Serialize(XmlNode node)
        {
            node.Attributes!.Append(node.OwnerDocument!.CreateAttribute("name")).Value = Name;
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("volume")).Value = VoiceSettings.Volume.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("lfoAssign")).Value = VoiceSettings.LFOAssign.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("lfoDepth")).Value = VoiceSettings.LFODepth.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("lfoSpeed")).Value = VoiceSettings.LFOSpeed.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("portamento")).Value = VoiceSettings.Portamento.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("oscType")).Value = VoiceSettings.OSCType.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("oscTexture")).Value = VoiceSettings.OSCTexture.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("oscMod")).Value = VoiceSettings.OSCMod.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("filterCutoff")).Value = VoiceSettings.FilterCutoff.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("filterResonance")).Value = VoiceSettings.FilterResonance.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("egBalance")).Value = VoiceSettings.EGBalance.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("egAttack")).Value = VoiceSettings.EGAttack.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("egDecay")).Value = VoiceSettings.EGDecay.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("egSustain")).Value = VoiceSettings.EGSustain.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("egRelease")).Value = VoiceSettings.EGRelease.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("fxType")).Value = VoiceSettings.FXType.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("fxDepth")).Value = VoiceSettings.FXDepth.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("fxRate")).Value = VoiceSettings.FXRate.ToString();
        }   

        public void Deserialize(XmlNode node)
        {
            var voiceSettings = new RefaceCSVoiceData();
            voiceSettings.Volume = byte.Parse(node.Attributes?["volume"]?.Value ?? throw new Exception("Missing volume"));
            voiceSettings.LFOAssign = (RefaceCSLFOAssign)Enum.Parse(typeof(RefaceCSLFOAssign), node.Attributes?["lfoAssign"]?.Value ?? throw new Exception("Missing lfoAssign"));
            voiceSettings.LFODepth = byte.Parse(node.Attributes?["lfoDepth"]?.Value ?? throw new Exception("Missing lfoDepth"));
            voiceSettings.LFOSpeed = byte.Parse(node.Attributes?["lfoSpeed"]?.Value ?? throw new Exception("Missing lfoSpeed"));
            voiceSettings.Portamento = byte.Parse(node.Attributes?["portamento"]?.Value ?? throw new Exception("Missing portamento"));
            voiceSettings.OSCType = (RefaceCSOSCType)Enum.Parse(typeof(RefaceCSOSCType), node.Attributes?["oscType"]?.Value ?? throw new Exception("Missing oscType"));
            voiceSettings.OSCTexture = byte.Parse(node.Attributes?["oscTexture"]?.Value ?? throw new Exception("Missing oscTexture"));
            voiceSettings.OSCMod = byte.Parse(node.Attributes?["oscMod"]?.Value ?? throw new Exception("Missing oscMod"));
            voiceSettings.FilterCutoff = byte.Parse(node.Attributes?["filterCutoff"]?.Value ?? throw new Exception("Missing filterCutoff"));
            voiceSettings.FilterResonance = byte.Parse(node.Attributes?["filterResonance"]?.Value ?? throw new Exception("Missing filterResonance"));
            voiceSettings.EGBalance = byte.Parse(node.Attributes?["egBalance"]?.Value ?? throw new Exception("Missing egBalance"));
            voiceSettings.EGAttack = byte.Parse(node.Attributes?["egAttack"]?.Value ?? throw new Exception("Missing egAttack"));
            voiceSettings.EGDecay = byte.Parse(node.Attributes?["egDecay"]?.Value ?? throw new Exception("Missing egDecay"));
            voiceSettings.EGSustain = byte.Parse(node.Attributes?["egSustain"]?.Value ?? throw new Exception("Missing egSustain"));
            voiceSettings.EGRelease = byte.Parse(node.Attributes?["egRelease"]?.Value ?? throw new Exception("Missing egRelease"));
            voiceSettings.FXType = (RefaceCSFXType)Enum.Parse(typeof(RefaceCSFXType), node.Attributes?["fxType"]?.Value ?? throw new Exception("Missing fxType"));
            voiceSettings.FXDepth = byte.Parse(node.Attributes?["fxDepth"]?.Value ?? throw new Exception("Missing fxDepth"));
            voiceSettings.FXRate = byte.Parse(node.Attributes?["fxRate"]?.Value ?? throw new Exception("Missing fxRate"));
            VoiceSettings = voiceSettings;
        }


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

            public static bool operator !=(RefaceCSVoiceData a, RefaceCSVoiceData b) => !(a == b);
            public static bool operator ==(RefaceCSVoiceData a, RefaceCSVoiceData b) => 
                a.Volume == b.Volume &&
                a.LFOAssign == b.LFOAssign &&
                a.LFODepth == b.LFODepth &&
                a.LFOSpeed == b.LFOSpeed &&
                a.Portamento == b.Portamento &&
                a.OSCType == b.OSCType &&
                a.OSCTexture == b.OSCTexture &&
                a.OSCMod == b.OSCMod &&
                a.FilterCutoff == b.FilterCutoff &&
                a.FilterResonance == b.FilterResonance &&
                a.EGBalance == b.EGBalance &&
                a.EGAttack == b.EGAttack &&
                a.EGDecay == b.EGDecay &&
                a.EGSustain == b.EGSustain &&
                a.EGRelease == b.EGRelease &&
                a.FXType == b.FXType &&
                a.FXDepth == b.FXDepth &&
                a.FXRate == b.FXRate;

            public override readonly bool Equals(object? obj) => obj is RefaceCSVoiceData data && this == data;

            public override readonly int GetHashCode() => HashCode.Combine(HashCode.Combine(Volume, LFOAssign, LFODepth, LFOSpeed, Portamento, OSCType, OSCTexture, OSCMod), HashCode.Combine(FilterCutoff, FilterResonance, EGBalance, EGAttack, EGDecay, EGSustain, EGRelease, FXType), FXDepth, FXRate);
        }

        public enum RefaceCSLFOAssign : byte { Off = 0, Amp = 1, Filter = 2, Pitch = 3, Oscillator = 4 }
        public enum RefaceCSOSCType : byte { Saw = 0, Pulse = 1, OscSync = 2, RingMod = 3, FM = 4 }
        public enum RefaceCSFXType : byte { Distortion = 0, ChorusFlanger = 1, Phaser = 2, Delay = 3, Thru = 4 }


    }
}
