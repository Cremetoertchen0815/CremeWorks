using CremeWorks.Reface;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;

namespace CremeWorks
{
    class SysExMan
    {

        private static byte GetModelID(DeviceType t)
        {
            switch (t)
            {
                case DeviceType.RefaceCS:
                    return 0x03;
                case DeviceType.RefaceDX:
                    return 0x05;
                case DeviceType.RefaceCP:
                    return 0x04;
                default:
                    return 0;
            }
        }
        public static void SendSystemBulkdumpRequest(OutputDevice d, DeviceType t) => d?.SendEvent(new NormalSysExEvent(new byte[] { 0x43, 0x20, 0x7F, 0x1C, GetModelID(t), 0x00, 0x00, 0x00, 0xF7 })); //Request device settings

        public static void SendVoiceBulkdumpRequest(OutputDevice d, DeviceType t)
        {
            if (t == DeviceType.Undefined || t == DeviceType.RefaceDX) return;
            d?.SendEvent(new NormalSysExEvent(new byte[] { 0x43, 0x20, 0x7F, 0x1C, GetModelID(t), 0x0E, 0x0F, 0x00, 0xF7 })); //Request device settings
        }


        public static void SendParameterChange(OutputDevice d, DeviceType t, byte[] startAddr, byte[] data)
        {
            //Create event

            for (int i = 0; i < data.Length; i++)
            {
                d?.SendEvent(new NormalSysExEvent(new byte[] { 0x43, 0x10, 0x7F, 0x1C, GetModelID(t), startAddr[0], startAddr[1], (byte)(startAddr[2] + i), data[i], 0xF7 })); //Send parameter change
            }
        }

    }
}
