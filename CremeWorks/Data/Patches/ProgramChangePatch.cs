using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using System.Xml;

namespace CremeWorks.App.Data.Patches;

public class ProgramChangePatch(string name) : IDevicePatch
{
    public string Name { get; set; } = name;
    public MidiDeviceType DeviceType => MidiDeviceType.GenericKeyboard;
    public byte ProgramChangeNr { get; set; }

    public void ApplyPatch(IDataParent parent, int deviceId)
    {
        if (!parent.MidiManager.TryGetMidiDevicePort(deviceId, out _, out var outputDevice) || outputDevice is null) return;
        outputDevice.SendEvent(new ProgramChangeEvent(new SevenBitNumber(ProgramChangeNr)));
    }

    public void ApplyPatch(int deviceId) => throw new NotImplementedException();
    public IDevicePatch Clone() => (IDevicePatch)MemberwiseClone();
    public bool AreEqual(IDevicePatch? other) => other is ProgramChangePatch c && c.ProgramChangeNr == ProgramChangeNr;

    public void Serialize(XmlNode node) => node.Attributes!.Append(node.OwnerDocument!.CreateAttribute("programChangeNr")).Value = ProgramChangeNr.ToString();
    public void Deserialize(XmlNode node) => ProgramChangeNr = byte.Parse(node.Attributes?["programChangeNr"]?.Value ?? throw new Exception("Missing programChangeNr"));
}