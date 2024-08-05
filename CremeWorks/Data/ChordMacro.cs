namespace CremeWorks.App.Data;

public class ChordMacro
{
    public string Name { get; set; } = "New Macro";
    public int TriggerNote { get; set; }
    public int Velocity { get; set; }
    public List<int> PlayNotes { get; } = [];

    public ChordMacro Clone()
    {
        var c = new ChordMacro
        {
            Name = Name,
            TriggerNote = TriggerNote,
            Velocity = Velocity
        };
        foreach (var n in PlayNotes) c.PlayNotes.Add(n);
        return c;
    }
}