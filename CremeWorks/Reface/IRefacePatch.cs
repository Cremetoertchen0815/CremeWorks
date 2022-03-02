namespace CremeWorks.Reface
{
    public interface IRefacePatch
    {
        RefaceSystemData SystemSettings { get; set; }
        DeviceType Type { get; }
        void ApplySettings(MIDIDevice d);
        void ApplyPatch(MIDIDevice d);
    }
}
