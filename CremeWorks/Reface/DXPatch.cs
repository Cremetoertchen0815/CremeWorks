using CremeWorks.App.Data;
using CremeWorks.App.Reface;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;

namespace CremeWorks.Reface
{
    internal class DXPatch : IDevicePatch
    {
        //public RefaceSystemData SystemSettings { get; set; }
        public byte ProgramChangeNr { get; set; }
        //public DeviceType Type => DeviceType.RefaceDX;

        public string Name => "throw new NotImplementedException()";

        public MidiDeviceType DeviceType => throw new NotImplementedException();

        //public void ApplyPatch(MIDIDevice d) => d.Output?.SendEvent(new ProgramChangeEvent(new SevenBitNumber(ProgramChangeNr)));
        public void ApplyPatch(int deviceId) => throw new NotImplementedException();
        //public void ApplySettings(MIDIDevice d) => CommonHelpers.SendParameterChange(d?.Output, Type, new byte[] { 0, 0, 0 }, StructMarshal<RefaceSystemData>.getBytes(SystemSettings));
        public IDevicePatch Clone() => (IDevicePatch)MemberwiseClone();
    }
}
