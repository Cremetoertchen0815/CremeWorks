using System.Runtime.InteropServices;
using System.Xml;
using CremeWorks.App.Data;
using CremeWorks.App.Reface;
using static CremeWorks.App.Data.Patches.CPPatch;

namespace CremeWorks.App.Data.Patches
{
    public class YCPatch(string name) : IDevicePatch
    {
        public string Name { get; init; } = name;
        public MidiDeviceType DeviceType => MidiDeviceType.RefaceYC;
        public RefaceYCVoiceData VoiceSettings { get; set; }

        public void ApplyPatch(IDataParent parent, int deviceId)
        {
            if (!parent.MidiManager.TryGetMidiDevicePort(deviceId, out _, out var outputDevice) || outputDevice is null) return;
            CommonHelpers.SendParameterChange(outputDevice, CommonHelpers.GetRefaceType(DeviceType), [0x30, 0, 0], StructMarshal<RefaceYCVoiceData>.getBytes(VoiceSettings));
        }

        public IDevicePatch Clone() => (IDevicePatch)MemberwiseClone();
        public void ApplyPatch(int deviceId) => throw new NotImplementedException();
        public bool AreEqual(IDevicePatch? other) => other is YCPatch c && c.VoiceSettings == VoiceSettings;

        public void Serialize(XmlNode node)
        {
            node.Attributes!.Append(node.OwnerDocument!.CreateAttribute("name")).Value = Name;
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("volume")).Value = VoiceSettings.Volume.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("voiceType")).Value = VoiceSettings.VoiceType.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("footage16")).Value = VoiceSettings.Footage16.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("footage5_13")).Value = VoiceSettings.Footage5_13.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("footage8")).Value = VoiceSettings.Footage8.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("footage4")).Value = VoiceSettings.Footage4.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("footage2_23")).Value = VoiceSettings.Footage2_23.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("footage2")).Value = VoiceSettings.Footage2.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("footage1_35")).Value = VoiceSettings.Footage1_35.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("footage1_13")).Value = VoiceSettings.Footage1_13.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("footage1")).Value = VoiceSettings.Footage1.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("vibratoChorusSwitch")).Value = VoiceSettings.VibratoChorusSwitch.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("vibratoChorusDepth")).Value = VoiceSettings.VibratoChorusDepth.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("percussionOnOff")).Value = VoiceSettings.PercussionOnOff.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("percussionType")).Value = VoiceSettings.PercussionType.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("percussionLength")).Value = VoiceSettings.PercussionLength.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("rotarySpeakerSpeed")).Value = VoiceSettings.RotarySpeakerSpeed.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("distortionDrive")).Value = VoiceSettings.DistortionDrive.ToString();
            node.Attributes.Append(node.OwnerDocument.CreateAttribute("reverbDepth")).Value = VoiceSettings.ReverbDepth.ToString();
        }

        public void Deserialize(XmlNode node)
        {
            var voiceSettings = new RefaceYCVoiceData();
            voiceSettings.Volume = byte.Parse(node.Attributes?["volume"]?.Value ?? throw new Exception("Missing volume"));
            voiceSettings.VoiceType = (RefaceYCVoiceType)Enum.Parse(typeof(RefaceYCVoiceType), node.Attributes?["voiceType"]?.Value ?? throw new Exception("Missing voiceType"));
            voiceSettings.Footage16 = byte.Parse(node.Attributes?["footage16"]?.Value ?? throw new Exception("Missing footage16"));
            voiceSettings.Footage5_13 = byte.Parse(node.Attributes?["footage5_13"]?.Value ?? throw new Exception("Missing footage5_13"));
            voiceSettings.Footage8 = byte.Parse(node.Attributes?["footage8"]?.Value ?? throw new Exception("Missing footage8"));
            voiceSettings.Footage4 = byte.Parse(node.Attributes?["footage4"]?.Value ?? throw new Exception("Missing footage4"));
            voiceSettings.Footage2_23 = byte.Parse(node.Attributes?["footage2_23"]?.Value ?? throw new Exception("Missing footage2_23"));
            voiceSettings.Footage2 = byte.Parse(node.Attributes?["footage2"]?.Value ?? throw new Exception("Missing footage2"));
            voiceSettings.Footage1_35 = byte.Parse(node.Attributes?["footage1_35"]?.Value ?? throw new Exception("Missing footage1_35"));
            voiceSettings.Footage1_13 = byte.Parse(node.Attributes?["footage1_13"]?.Value ?? throw new Exception("Missing footage1_13"));
            voiceSettings.Footage1 = byte.Parse(node.Attributes?["footage1"]?.Value ?? throw new Exception("Missing footage1"));
            voiceSettings.VibratoChorusSwitch = (RefaceYCVibratoSwitch)Enum.Parse(typeof(RefaceYCVibratoSwitch), node.Attributes?["vibratoChorusSwitch"]?.Value ?? throw new Exception("Missing vibratoChorusSwitch"));
            voiceSettings.VibratoChorusDepth = byte.Parse(node.Attributes?["vibratoChorusDepth"]?.Value ?? throw new Exception("Missing vibratoChorusDepth"));
            voiceSettings.PercussionOnOff = byte.Parse(node.Attributes?["percussionOnOff"]?.Value ?? throw new Exception("Missing percussionOnOff"));
            voiceSettings.PercussionType = (RefaceYCPercussionType)Enum.Parse(typeof(RefaceYCPercussionType), node.Attributes?["percussionType"]?.Value ?? throw new Exception("Missing percussionType"));
            voiceSettings.PercussionLength = byte.Parse(node.Attributes?["percussionLength"]?.Value ?? throw new Exception("Missing percussionLength"));
            voiceSettings.RotarySpeakerSpeed = (RefaceYCRotarySpeakerSetting)Enum.Parse(typeof(RefaceYCRotarySpeakerSetting), node.Attributes?["rotarySpeakerSpeed"]?.Value ?? throw new Exception("Missing rotarySpeakerSpeed"));
            voiceSettings.DistortionDrive = byte.Parse(node.Attributes?["distortionDrive"]?.Value ?? throw new Exception("Missing distortionDrive"));
            voiceSettings.ReverbDepth = byte.Parse(node.Attributes?["reverbDepth"]?.Value ?? throw new Exception("Missing reverbDepth"));
            VoiceSettings = voiceSettings;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RefaceYCVoiceData
        {
            public byte Volume;
            public byte Reserved1;
            public RefaceYCVoiceType VoiceType;
            public byte Footage16;
            public byte Footage5_13;
            public byte Footage8;
            public byte Footage4;
            public byte Footage2_23;
            public byte Footage2;
            public byte Footage1_35;
            public byte Footage1_13;
            public byte Footage1;
            public RefaceYCVibratoSwitch VibratoChorusSwitch;
            public byte VibratoChorusDepth;
            public byte PercussionOnOff;
            public RefaceYCPercussionType PercussionType;
            public byte PercussionLength;
            public RefaceYCRotarySpeakerSetting RotarySpeakerSpeed;
            public byte DistortionDrive;
            public byte ReverbDepth;
            public short Reserved2;

            public static bool operator ==(RefaceYCVoiceData a, RefaceYCVoiceData b) =>
                a.Volume == b.Volume &&
                a.VoiceType == b.VoiceType &&
                a.Footage16 == b.Footage16 &&
                a.Footage5_13 == b.Footage5_13 &&
                a.Footage8 == b.Footage8 &&
                a.Footage4 == b.Footage4 &&
                a.Footage2_23 == b.Footage2_23 &&
                a.Footage2 == b.Footage2 &&
                a.Footage1_35 == b.Footage1_35 &&
                a.Footage1_13 == b.Footage1_13 &&
                a.Footage1 == b.Footage1 &&
                a.VibratoChorusSwitch == b.VibratoChorusSwitch &&
                a.VibratoChorusDepth == b.VibratoChorusDepth &&
                a.PercussionOnOff == b.PercussionOnOff &&
                a.PercussionType == b.PercussionType &&
                a.PercussionLength == b.PercussionLength &&
                a.RotarySpeakerSpeed == b.RotarySpeakerSpeed &&
                a.DistortionDrive == b.DistortionDrive &&
                a.ReverbDepth == b.ReverbDepth;

            public static bool operator !=(RefaceYCVoiceData a, RefaceYCVoiceData b) => !(a == b);
            public override bool Equals(object? obj) => obj is RefaceYCVoiceData data && this == data;
            public override int GetHashCode() => HashCode.Combine(HashCode.Combine(Volume, VoiceType, Footage16, Footage5_13, Footage8, Footage4, Footage2_23, Footage2), HashCode.Combine(Footage1_35, Footage1_13, Footage1, VibratoChorusSwitch, VibratoChorusDepth, PercussionOnOff, PercussionType, PercussionLength), HashCode.Combine(RotarySpeakerSpeed, DistortionDrive, ReverbDepth));
        }


        public enum RefaceYCVoiceType : byte { H = 0, V = 1, F = 2, A = 3, Y = 4 }
        public enum RefaceYCVibratoSwitch : byte { Vibrato = 0, Chorus = 1 }
        public enum RefaceYCPercussionType : byte { A = 0, B = 1 }
        public enum RefaceYCRotarySpeakerSetting : byte { Off = 0, Stop = 1, Slow = 2, Fast = 3 }
    }
}
