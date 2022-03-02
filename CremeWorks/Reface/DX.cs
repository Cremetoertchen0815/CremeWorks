namespace CremeWorks.Reface
{
    class DX : IRefaceDevice
    {
        public RefaceSystemData SystemSettings { get; set; }
        public byte ProgramChangeNr { get; set; }
        public DeviceType Type => DeviceType.RefaceDX;
    }
}
