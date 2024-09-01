namespace CremeWorks.App.Data;

public class SoloModeConfiguration
{
    public bool Enabled { get; set; } = false;
    public byte CCNumber { get; set; } = 7;
    public byte DefaultValue { get; set; } = 100;
    public byte SoloValue { get; set; } = 127;
    public List<int> Devices { get; } = [];
    public float? FadeDurationSeconds { get; set; } = null;
}
