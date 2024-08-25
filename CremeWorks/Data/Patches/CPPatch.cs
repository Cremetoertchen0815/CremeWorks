using CremeWorks.App.Data;
using System.Runtime.InteropServices;
using System.Xml;

namespace CremeWorks.App.Data.Patches
{
    public class CPPatch(string name) : IDevicePatch
    {
        public string Name { get; init; } = name;
        public MidiDeviceType DeviceType => MidiDeviceType.RefaceCP;
        public RefaceCPVoiceData VoiceSettings { get; set; }


        public void ApplyPatch(int deviceId) { return; } // => CommonHelpers.SendParameterChange(d?.Output, CommonHelpers.GetRefaceType(DeviceType), new byte[] { 0x30, 0, 0 }, StructMarshal<RefaceCPVoiceData>.getBytes(VoiceSettings));
        public IDevicePatch Clone() => (IDevicePatch)MemberwiseClone();
        public bool AreEqual(IDevicePatch other) => other is CPPatch c && c.VoiceSettings == VoiceSettings;

        public void Serialize(XmlNode node)
        {
            node.Attributes!.Append(node.OwnerDocument!.CreateAttribute("name")).Value = Name;
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("waveType")).Value = VoiceSettings.WaveType.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("drive")).Value = VoiceSettings.Drive.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("effectAType")).Value = VoiceSettings.EffectAType.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("effectADepth")).Value = VoiceSettings.EffectADepth.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("effectARate")).Value = VoiceSettings.EffectARate.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("effectBType")).Value = VoiceSettings.EffectBType.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("effectBDepth")).Value = VoiceSettings.EffectBDepth.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("effectBSpeed")).Value = VoiceSettings.EffectBSpeed.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("effectCType")).Value = VoiceSettings.EffectCType.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("effectCDepth")).Value = VoiceSettings.EffectCDepth.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("effectCTime")).Value = VoiceSettings.EffectCTime.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("reverbDepth")).Value = VoiceSettings.ReverbDepth.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("volume")).Value = VoiceSettings.Volume.ToString();
        }

        public void Deserialize(XmlNode node)
        {
            var voiceSettings = new RefaceCPVoiceData();
            voiceSettings.WaveType = (RefaceCPWaveType)Enum.Parse(typeof(RefaceCPWaveType), node.Attributes?["waveType"]?.Value ?? throw new Exception("Missing waveType"));
            voiceSettings.Drive = byte.Parse(node.Attributes?["drive"]?.Value ?? throw new Exception("Missing drive"));
            voiceSettings.EffectAType = (RefaceCPEffectA)Enum.Parse(typeof(RefaceCPEffectA), node.Attributes?["effectAType"]?.Value ?? throw new Exception("Missing effectAType"));
            voiceSettings.EffectADepth = byte.Parse(node.Attributes?["effectADepth"]?.Value ?? throw new Exception("Missing effectADepth"));
            voiceSettings.EffectARate = byte.Parse(node.Attributes?["effectARate"]?.Value ?? throw new Exception("Missing effectARate"));
            voiceSettings.EffectBType = (RefaceCPEffectB)Enum.Parse(typeof(RefaceCPEffectB), node.Attributes?["effectBType"]?.Value ?? throw new Exception("Missing effectBType"));
            voiceSettings.EffectBDepth = byte.Parse(node.Attributes?["effectBDepth"]?.Value ?? throw new Exception("Missing effectBDepth"));
            voiceSettings.EffectBSpeed = byte.Parse(node.Attributes?["effectBSpeed"]?.Value ?? throw new Exception("Missing effectBSpeed"));
            voiceSettings.EffectCType = (RefaceCPEffectC)Enum.Parse(typeof(RefaceCPEffectC), node.Attributes?["effectCType"]?.Value ?? throw new Exception("Missing effectCType"));
            voiceSettings.EffectCDepth = byte.Parse(node.Attributes?["effectCDepth"]?.Value ?? throw new Exception("Missing effectCDepth"));
            voiceSettings.EffectCTime = byte.Parse(node.Attributes?["effectCTime"]?.Value ?? throw new Exception("Missing effectCTime"));
            voiceSettings.ReverbDepth = byte.Parse(node.Attributes?["reverbDepth"]?.Value ?? throw new Exception("Missing reverbDepth"));
            voiceSettings.Volume = byte.Parse(node.Attributes?["volume"]?.Value ?? throw new Exception("Missing volume"));
            VoiceSettings = voiceSettings;
        }

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

            public static bool operator ==(RefaceCPVoiceData a, RefaceCPVoiceData b) => a.Volume == b.Volume && a.WaveType == b.WaveType && a.Drive == b.Drive && a.EffectAType == b.EffectAType && a.EffectADepth == b.EffectADepth && a.EffectARate == b.EffectARate && a.EffectBType == b.EffectBType && a.EffectBDepth == b.EffectBDepth && a.EffectBSpeed == b.EffectBSpeed && a.EffectCType == b.EffectCType && a.EffectCDepth == b.EffectCDepth && a.EffectCTime == b.EffectCTime && a.ReverbDepth == b.ReverbDepth;
            public static bool operator !=(RefaceCPVoiceData a, RefaceCPVoiceData b) => !(a == b);
            public override readonly bool Equals(object? obj) => obj is RefaceCPVoiceData data && this == data;
            public override int GetHashCode() => HashCode.Combine(HashCode.Combine(WaveType, Drive, EffectAType, EffectADepth, EffectARate, EffectBType, EffectBDepth, EffectBSpeed), HashCode.Combine(EffectCType, EffectCDepth, EffectCTime, ReverbDepth, Volume));
        }


        public enum RefaceCPWaveType : byte { RdI = 0, RdII = 1, Wr = 2, Clv = 3, Toy = 4, CP = 5, Pno = 6 }
        public enum RefaceCPEffectA : byte { Thru = 0, Tremolo = 1, Wah = 2 }
        public enum RefaceCPEffectB : byte { Thru = 0, Chorus = 1, Phaser = 2 }
        public enum RefaceCPEffectC : byte { Thru = 0, DDelay = 1, ADelay = 2 }
    }
}
