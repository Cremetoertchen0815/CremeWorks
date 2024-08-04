namespace CremeWorks.App.Data;

public record struct MidiMatrixNode(uint SourceDeviceId, uint DestinationDeviceId, MidiMatrixNodeType Type);

public enum MidiMatrixNodeType
{
    None,
    Notes,
    ControlChange,
    Both
}