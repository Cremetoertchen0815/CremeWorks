using System.Runtime.InteropServices;

namespace CremeWorks.Reface
{

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RefaceSystemData
    {
        public byte MIDIChannelTransmit;
        public byte MIDIChannelReceive;
        public uint MasterTune;
        public byte LocalControl;
        public byte MasterTranspose;
        public ushort Tempo;
        public byte LCDContrast;
        public byte SustainPedalSelect;
        public byte AutoPwrOff;
        public byte SpkOut;
        public byte MIDICtrl;
        public byte GlobalPBRange;
        public int Reserved2;
        public byte FootSwitchMode;
        public byte Reserved3;
        public short Reserved4;
        public int Reserved5;
        public int Reserved6;
    }

    public enum DeviceType { Undefined = 0, RefaceCS = 1, RefaceDX = 2, RefaceCP = 3, RefaceYC = 4 }
}
