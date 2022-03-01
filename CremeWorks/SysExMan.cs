using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
        public static void SendSystemBulkdumpRequest(OutputDevice d, DeviceType t) => d.SendEvent(new NormalSysExEvent(new byte[] { 0x43, 0x20, 0x7F, 0x1C, GetModelID(t), 0x00, 0x00, 0x00, 0xF7 })); //Request device settings

        public static void SendVoiceBulkdumpRequest(OutputDevice d, DeviceType t)
        {
            switch (t)
            {
                case DeviceType.RefaceCS:
                    break;
                case DeviceType.RefaceDX:
                    break;
                case DeviceType.RefaceCP:
                    d.SendEvent(new NormalSysExEvent(new byte[] { 0x43, 0x20, 0x7F, 0x1C, 0x04, 0x0E, 0x0F, 0x00, 0xF7 })); //Request device settings
                    break;
                default:
                    break;
            }
        }


    }
}
