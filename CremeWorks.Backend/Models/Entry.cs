namespace CremeWorks.Backend.Models;

public class Entry
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int CreatorId { get; set; }
    public User? Creator { get; set; }
    public int Hash { get; set; }
    public bool IsPublic { get; set; }
    public DateTime LastTimeUpdated { get; set; }
    public int? ContentId { get; set; }
    public ContentBlob? Content { get; set; }
}
