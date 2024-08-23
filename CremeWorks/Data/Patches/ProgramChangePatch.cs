namespace CremeWorks.App.Data.Patches;

public class ProgramChangePatch(string name) : IDevicePatch
{
    public string Name { get; init; } = name;
    public MidiDeviceType DeviceType => MidiDeviceType.GenericKeyboard;
    public byte ProgramChangeNr { get; set; }


    //public void ApplyPatch(MIDIDevice d) => d.Output?.SendEvent(new ProgramChangeEvent(new SevenBitNumber(ProgramChangeNr)));
    public void ApplyPatch(int deviceId) => throw new NotImplementedException();
    public IDevicePatch Clone() => (IDevicePatch)MemberwiseClone();
}