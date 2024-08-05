namespace CremeWorks.App.Data;

public class ChordMacro
{
    public ChordMacro(string name, int triggerNote, int velocity, List<int> playNotes)
    {
        Name = name;
        TriggerNote = triggerNote;
        Velocity = velocity;
        PlayNotes = playNotes;
    }

    public string Name { get; set; } = "New Macro";
    public int TriggerNote { get; set; }
    public int Velocity { get; set; }
    public List<int> PlayNotes { get; init; }

    public ChordMacro Clone()
    {
        var c = new ChordMacro
        (
            Name,
            TriggerNote,
            Velocity,
            []
        );
        foreach (var n in PlayNotes) c.PlayNotes.Add(n);
        return c;
    }
}