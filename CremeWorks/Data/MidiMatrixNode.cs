namespace CremeWorks.App.Data;

public record struct MidiMatrixNode(int SourceDeviceId, int DestinationDeviceId, MidiMatrixNodeType Type);

public enum MidiMatrixNodeType
{
    None,
    Notes,
    ControlChange,
    Both
}