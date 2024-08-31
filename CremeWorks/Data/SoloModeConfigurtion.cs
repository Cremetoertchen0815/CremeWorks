namespace CremeWorks.App.Data;

public class SoloModeConfigurtion
{
    public bool Enabled { get; set; } = false;
    public int CCNumber { get; set; } = 7;
    public int RegularValue { get; set; } = 100;
    public int SoloValue { get; set; } = 127;
    public List<int> Devices { get; } = [];
    public float? FadeDurationSeconds { get; set; } = null;
}
