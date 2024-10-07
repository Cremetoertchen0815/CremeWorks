namespace CremeWorks.DTO;

public class CloudEntryInformation
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Creator { get; set; }
    public long LastTimeUpdated { get; set; }
    public string Hash { get; set; } = null!;
    public bool IsPublic { get; set; }
}
