namespace CremeWorks.App.Data;

public record LightingCueItem(ulong Id, byte NoteValue, string Name)
{
    public override string ToString() => Name;
}