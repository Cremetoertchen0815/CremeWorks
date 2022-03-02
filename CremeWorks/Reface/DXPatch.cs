using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;

namespace CremeWorks.Reface
{
    class DXPatch : IRefacePatch
    {
        public RefaceSystemData SystemSettings { get; set; }
        public byte ProgramChangeNr { get; set; }
        public DeviceType Type => DeviceType.RefaceDX;

        public void ApplyPatch(MIDIDevice d) => d.Output?.SendEvent(new ProgramChangeEvent(new SevenBitNumber(ProgramChangeNr)));
        public void ApplySettings(MIDIDevice d) => SysExMan.SendParameterChange(d?.Output, Type, new byte[] { 0, 0, 0 }, StructMarshal<RefaceSystemData>.getBytes(SystemSettings));
        public IRefacePatch Clone() => (IRefacePatch)MemberwiseClone();
    }
}
