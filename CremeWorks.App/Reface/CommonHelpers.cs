using CremeWorks.App.Data;
using CremeWorks.App.Midi;
using Melanchall.DryWetMidi.Core;

namespace CremeWorks.App.Reface
{
    public static class CommonHelpers
    {
        public enum RefaceType : byte
        { 
            Undefined = 0, 
            RefaceCS = 0x03,
            RefaceCP = 0x04,
            RefaceDX = 0x05, 
            RefaceYC = 0x06
        }

        public static RefaceType GetRefaceType(MidiDeviceType deviceType) => deviceType switch
        {
            MidiDeviceType.RefaceCS => RefaceType.RefaceCS,
            MidiDeviceType.RefaceCP => RefaceType.RefaceCP,
            MidiDeviceType.RefaceYC => RefaceType.RefaceYC,
            _ => RefaceType.Undefined,
        };
        
        public static void SendSystemBulkdumpRequest(IMidiOutputPort d, RefaceType t) => d?.SendEvent(new NormalSysExEvent([0x43, 0x20, 0x7F, 0x1C, (byte)t, 0x00, 0x00, 0x00, 0xF7])); //Request device settings

        public static void SendVoiceBulkdumpRequest(IMidiOutputPort d, RefaceType t)
        {
            if (t == RefaceType.Undefined || t == RefaceType.RefaceDX) return;
            d.SendEvent(new NormalSysExEvent([0x43, 0x20, 0x7F, 0x1C, (byte)t, 0x0E, 0x0F, 0x00, 0xF7])); //Request device settings
        }


        public static void SendParameterChange(IMidiOutputPort d, RefaceType t, byte[] startAddr, byte[] data)
        {
            //Send byte by byte
            try
            {
                for (int i = 0; i < data.Length; i++)
                    d.SendEvent(new NormalSysExEvent([0x43, 0x10, 0x7F, 0x1C, (byte)t, startAddr[0], startAddr[1], (byte)(startAddr[2] + i), data[i], 0xF7])); //Send parameter change
            }
            catch (Exception)
            {
            }
        }



    }
}
