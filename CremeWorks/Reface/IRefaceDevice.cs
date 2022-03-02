namespace CremeWorks.Reface
{
    public interface IRefaceDevice
    {
        RefaceSystemData SystemSettings { get; set; }
        DeviceType Type { get; }
    }
}
