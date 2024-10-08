using CremeWorks.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace CremeWorks.Backend.Services;

public class EntryService(IDbContextFactory<DataContext> _contextFactory)
{
    public async Task<IEnumerable<Entry>> GetEntriesAsync(int? userId)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Entries.Where(x => x.IsPublic || x.CreatorId == userId).Include(x => x.Creator).ToListAsync();
    }

    public async Task<Entry?> GetEntryWithCreatorAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Entries.Include(x => x.Creator).FirstOrDefaultAsync(e => e.Id == id);
    }
    public async Task<Entry?> GetEntryWithContentAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Entries.Include(x => x.Content).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<int> CreateEntryAsync(string name, int creatorId, bool isPublic)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var entry = new Entry { Name = name, CreatorId = creatorId, IsPublic = isPublic, Hash = string.Empty };
        await context.Entries.AddAsync(entry);
        await context.SaveChangesAsync();
        return entry.Id;
    }

    public async Task<bool> UpdateEntryAsync(int id, int userId, long syncTime, string hash, byte[] data)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var entry = await context.Entries.Include(x => x.Content).FirstOrDefaultAsync(e => e.Id == id);
        if (entry == null || entry.CreatorId != userId) return false;
        entry.Hash = hash;
        entry.Timestamp = syncTime;

        if (entry.Content == null)
        {
            entry.Content = new ContentBlob { Data = data };
        }
        else
        {
            entry.Content.Data = data;
        }
        await context.SaveChangesAsync();
        return true;
    }

    public async Task DeleteEntryAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var entry = await context.Entries.FirstOrDefaultAsync(e => e.Id == id);
        if (entry == null) return;
        context.Entries.Remove(entry);
        await context.SaveChangesAsync();
    }
}
