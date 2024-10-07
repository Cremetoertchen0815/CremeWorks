namespace CremeWorks.Backend.Models;

public class ContentBlob
{
    public int Id { get; set; }
    public required byte[] Data { get; set; }
    public int EntryId { get; set; }
    public required Entry Entry { get; set; }
}
