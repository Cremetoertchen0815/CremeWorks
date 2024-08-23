using System.Xml;

namespace CremeWorks.App.Data
{
    public interface IDevicePatch
    {
        string Name { get; }
        MidiDeviceType DeviceType { get; }
        void ApplyPatch(int deviceId);
        IDevicePatch Clone();
        void Serialize(XmlNode node);
        void Deserialize(XmlNode node);
    }
}
