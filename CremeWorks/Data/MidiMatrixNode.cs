namespace CremeWorks.App.Data;

public record struct MidiMatrixNode(int SourceDeviceId, int DestinationDeviceId, MidiMatrixNodeType Type);

[Flags]
public enum MidiMatrixNodeType
{
    None = 0b00,
    Notes = 0b01,
    ControlChange = 0b10,
    Both = 0b11
}