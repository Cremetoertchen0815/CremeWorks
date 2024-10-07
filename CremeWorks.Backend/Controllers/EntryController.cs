using CremeWorks.Backend.Models;
using CremeWorks.Backend.Services;
using CremeWorks.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CremeWorks.Backend.Controllers;

[ApiController]
public class EntryController(EntryService entries, UserService users) : Controller
{
    [HttpGet]
    [Route("/api/cremeworks/allentries")]
    public async Task<ActionResult<CloudEntryInformation[]>> GetAllEntries(int token)
    {
        if (!users.IsUserAuthorized(token, out var userId)) return Unauthorized();

        var data = await entries.GetEntriesAsync(userId);
        return Ok(data.Select(GetDTO).ToArray());
    }

    [HttpGet]
    [Route("/api/cremeworks/entryinfo")]
    public async Task<ActionResult<CloudEntryInformation>> GetEntryInfo(int token, int id)
    {
        if (!users.IsUserAuthorized(token, out var userId)) return Unauthorized();

        var entry = await entries.GetEntryWithCreatorAsync(id);
        if (entry == null) return NotFound();
        if (!entry.IsPublic && entry.CreatorId != userId) return Unauthorized();
        return Ok(GetDTO(entry));
    }

    [HttpGet]
    [Route("/api/cremeworks/entrydata")]
    public async Task<ActionResult<string>> GetEntryData(int token, int id)
    {
        if (!users.IsUserAuthorized(token, out var userId)) return Unauthorized();

        var entry = await entries.GetEntryWithContentAsync(id);
        if (entry == null) return NotFound();
        if (!entry.IsPublic && entry.CreatorId != userId) return Unauthorized();

        return Ok(System.Text.Encoding.UTF8.GetString(entry?.Content?.Data ?? []));
    }

    [HttpPost]
    [Route("/api/cremeworks/entrydata")]
    public async Task<ActionResult> CreateEntry(int token, int id, long synctime, string hash, [FromBody] string data)
    {
        if (!users.IsUserAuthorized(token, out var userId)) return Unauthorized();

        var bytes = System.Text.Encoding.UTF8.GetBytes(data);
        if (!await entries.UpdateEntryAsync(id, userId, synctime, hash, bytes)) return Unauthorized();
        return Ok();
    }

    [HttpPost]
    [Route("/api/cremeworks/publish")]
    public async Task<ActionResult<int>> PublishEntry(int token, string name, bool isPublic, long date, string hash, [FromBody] string data)
    {
        if (!users.IsUserAuthorized(token, out var userId)) return Unauthorized();

        var entryId = await entries.CreateEntryAsync(name, userId, isPublic);
        var bytes = System.Text.Encoding.UTF8.GetBytes(data);
        if (!await entries.UpdateEntryAsync(entryId, userId, date, hash, bytes)) return Unauthorized();

        return Ok(entryId);
    }

    private CloudEntryInformation GetDTO(Entry entry) => new()
    {
        Creator = entry.Creator?.Username ?? "Unknown",
        Name = entry.Name,
        Hash = entry.Hash,
        Id = entry.Id,
        IsPublic = entry.IsPublic,
        LastTimeUpdated = entry.Timestamp
    };
}
