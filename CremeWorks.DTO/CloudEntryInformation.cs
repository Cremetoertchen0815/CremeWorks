namespace CremeWorks.DTO;

public class CloudEntryInformation
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Creator { get; set; }
    public DateTime LastTimeUpdated { get; set; }
    public int Hash { get; set; }
    public bool IsPublic { get; set; }
}
