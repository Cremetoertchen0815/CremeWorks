namespace CremeWorks.Reface
{
    public interface IRefacePatch
    {
        RefaceSystemData SystemSettings { get; set; }
        DeviceType Type { get; }
    }
}
