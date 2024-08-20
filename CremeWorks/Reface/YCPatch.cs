﻿using System.Runtime.InteropServices;
using CremeWorks.App.Data;
using CremeWorks.App.Reface;

namespace CremeWorks.Reface
{
    internal class YCPatch : IDevicePatch
    {
        public string Name => throw new NotImplementedException();

        public MidiDeviceType DeviceType => throw new NotImplementedException();

        //public RefaceSystemData SystemSettings { get; set; }
        //public RefaceYCVoiceData VoiceSettings { get; set; }
        //public DeviceType Type => DeviceType.RefaceYC;

        //public void ApplySettings(MIDIDevice d) => CommonHelpers.SendParameterChange(d?.Output, Type, new byte[] { 0, 0, 0 }, StructMarshal<RefaceSystemData>.getBytes(SystemSettings));
        //public void ApplyPatch(MIDIDevice d) => CommonHelpers.SendParameterChange(d?.Output, Type, new byte[] { 0x30, 0, 0 }, StructMarshal<RefaceYCVoiceData>.getBytes(VoiceSettings));
        public IDevicePatch Clone() => (IDevicePatch)MemberwiseClone();
        public void ApplyPatch(int deviceId) => throw new NotImplementedException();

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
