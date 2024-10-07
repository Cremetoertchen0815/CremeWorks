namespace CremeWorks.Backend.Models;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
    public ICollection<Entry> Entries { get; set; } = [];
}
