namespace CremeWorks.App.Data;

public record ChordMacro(string Name, int TriggerNote, int Velocity, List<int> PlayNotes);