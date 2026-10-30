namespace CremeWorks.App.Data;

public record LightingCueItem(byte NoteValue, string Name)
{
    public override string ToString() => Name;
}