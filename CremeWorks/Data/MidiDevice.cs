namespace CremeWorks.App.Data;
public record MidiDevice(string Name, string MidiId, bool IsRemoteSource, MidiDeviceType Type)
{
    public bool IsInstrument => Type is not MidiDeviceType.Lighting and not MidiDeviceType.GenericController;
}

public enum MidiDeviceType
{
    Unknown = -1,
    GenericKeyboard = 0,
    GenericController = 1,
    Lighting = 2,
    RefaceCS = 3,
    RefaceCP = 4,
    RefaceYC = 5,
}