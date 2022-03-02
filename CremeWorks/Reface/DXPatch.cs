namespace CremeWorks.Reface
{
    class DXPatch : IRefacePatch
    {
        public RefaceSystemData SystemSettings { get; set; }
        public byte ProgramChangeNr { get; set; }
        public DeviceType Type => DeviceType.RefaceDX;
    }
}
