namespace CremeWorks.App.Data;
public record MidiDevice(string Name, string MidiId, bool IsRemoteSource, MidiDeviceType Type);

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