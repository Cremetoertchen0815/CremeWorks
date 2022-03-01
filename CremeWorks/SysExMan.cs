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
                    
                    break;
                default:
                    break;
            }
        }

        public enum DeviceType { RefaceCS, RefaceDX, RefaceCP }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RefaceSystemData
        {
            byte MIDIChannelTransmit;
            byte MIDIChannelReceive;
            int MasterTune;
            bool LocalControl;
            byte MasterTranspose;
            short Tempo;
            byte LCDContrast;
            bool SustainPedalSelect;
            bool AutoPwrOff;
            bool SpkOut;
            bool MIDICtrl;
            byte GlobalPBRange;
            int Reserved2;
            bool FootSwitchMode;
            byte Reserved3;
            short Reserved4;
            int Reserved5;
            int Reserved6;
        }
    }
}
