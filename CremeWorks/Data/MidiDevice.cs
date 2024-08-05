namespace CremeWorks.App.Data;
public record MidiDevice(string Name, string MidiId, bool IsRemoteSource, MidiDeviceType Type)
{
    public bool IsInstrument => Type is not MidiDeviceType.Lighting and not MidiDeviceType.GenericController;
}

public enum MidiDeviceType
{
    GenericKeyboard,
    GenericController,
    RefaceCS,
    RefaceDX,
    RefaceCP,
    RefaceYC,
    Lighting,
}