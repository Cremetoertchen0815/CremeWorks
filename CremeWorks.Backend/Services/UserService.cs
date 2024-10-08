using CremeWorks.Backend.Models;
using CremeWorks.Backend.Utils;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Security.Cryptography;

namespace CremeWorks.Backend.Services;

public class UserService(IDbContextFactory<DataContext> contextFactory) : BackgroundService
{
    private readonly ConcurrentDictionary<int, Session> _sessions = new();

    private const int SessionExpirationTimeMinutes = 60;
    private const int SessionCleanupIntervalMinutes = 5;

    public async Task<int?> CreateSessionAsync(string username, string password)
    {
        //Check if user exists and load user
        using var context = await contextFactory.CreateDbContextAsync();
        var user = await context.Users.FirstOrDefaultAsync(x => x.Username == username);
        if (user == null)
        {
            return null;
        }

        //Check if password is correct
        var hash = await PasswordHash.HashPasswordAsync(password, user.PasswordSalt);
        if (hash != user.PasswordHash) return null;

        //Generate token and register session
        int sessionToken;
        var session = new Session { UserId = user.Id, ExpirationDate = DateTime.UtcNow.AddMinutes(SessionExpirationTimeMinutes) };
        do
        {
            sessionToken = RandomNumberGenerator.GetInt32(int.MaxValue);
        }
        while (!_sessions.TryAdd(sessionToken, session));

        return sessionToken;
    }

    public bool ValidateSession(int sessionToken)
    {
        if (!_sessions.TryGetValue(sessionToken, out var session)) return false;
        if (session.ExpirationDate < DateTime.UtcNow)
        {
            _sessions.TryRemove(sessionToken, out _);
            return false;
        }

        session.ExpirationDate = DateTime.UtcNow.AddMinutes(SessionExpirationTimeMinutes);
        return true;
    }

    public async Task<User?> GetUserAsync(int sessionToken)
    {
        if (!_sessions.TryGetValue(sessionToken, out var session)) return null;
        if (session.ExpirationDate < DateTime.UtcNow)
        {
            _sessions.TryRemove(sessionToken, out _);
            return null;
        }

        using var context = await contextFactory.CreateDbContextAsync();
        return await context.Users.FindAsync(session.UserId);
    }

    public async Task<bool> CreateUser(string username, string password)
    {
        //Check if user already exists
        using var context = await contextFactory.CreateDbContextAsync();
        if (await context.Users.AnyAsync(x => x.Username == username)) return false;

        //Generate salt and hash password
        var salt = PasswordHash.GenerateSalt();
        var hash = await PasswordHash.HashPasswordAsync(password, salt);

        //Save user to database
        await context.Users.AddAsync(new User { Username = username, PasswordHash = hash, PasswordSalt = salt });
        await context.SaveChangesAsync();
        return true;
    }

    public bool IsUserAuthorized(int sessionToken, out int userId)
    {
        userId = -1;
        if (!_sessions.TryGetValue(sessionToken, out var session)) return false;
        if (session.ExpirationDate < DateTime.UtcNow)
        {
            _sessions.TryRemove(sessionToken, out _);
            return false;
        }

        userId = session.UserId;
        return true;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMinutes(SessionCleanupIntervalMinutes), stoppingToken);

            var now = DateTime.UtcNow;
            foreach (var (token, session) in _sessions)
            {
                if (session.ExpirationDate < now)
                {
                    _sessions.TryRemove(token, out _);
                }
            }
        }
    }
}
