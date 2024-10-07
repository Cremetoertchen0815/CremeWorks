namespace CremeWorks.Backend.Models;

public record struct Session(int UserId, DateTime ExpirationDate);