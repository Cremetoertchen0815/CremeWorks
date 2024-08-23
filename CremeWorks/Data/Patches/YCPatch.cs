using System.Runtime.InteropServices;
using System.Xml;
using CremeWorks.App.Data;

namespace CremeWorks.App.Data.Patches
{
    public class YCPatch(string name) : IDevicePatch
    {
        public string Name { get; init; } = name;
        public MidiDeviceType DeviceType => MidiDeviceType.RefaceYC;
        public RefaceYCVoiceData VoiceSettings { get; set; }

        //public void ApplySettings(MIDIDevice d) => CommonHelpers.SendParameterChange(d?.Output, Type, new byte[] { 0, 0, 0 }, StructMarshal<RefaceSystemData>.getBytes(SystemSettings));
        //public void ApplyPatch(MIDIDevice d) => CommonHelpers.SendParameterChange(d?.Output, Type, new byte[] { 0x30, 0, 0 }, StructMarshal<RefaceYCVoiceData>.getBytes(VoiceSettings));
        public IDevicePatch Clone() => (IDevicePatch)MemberwiseClone();
        public void ApplyPatch(int deviceId) => throw new NotImplementedException();

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
        }


        public enum RefaceYCVoiceType : byte { H = 0, V = 1, F = 2, A = 3, Y = 4 }
        public enum RefaceYCVibratoSwitch : byte { Vibrato = 0, Chorus = 1 }
        public enum RefaceYCPercussionType : byte { A = 0, B = 1 }
        public enum RefaceYCRotarySpeakerSetting : byte { Off = 0, Stop = 1, Slow = 2, Fast = 3 }
    }
}
