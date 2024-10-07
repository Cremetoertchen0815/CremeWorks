using CremeWorks.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CremeWorks.Backend.Controllers;

[ApiController]
public class EntryController : Controller
{
    [HttpGet]
    [Route("/api/cremeworks/allentries")]
    public ActionResult<CloudEntryInformation[]> GetAllEntries(int token)
    {
        return Ok(new CloudEntryInformation[] { new CloudEntryInformation() { 
            Creator = "Super Mario",
            Name = "Super Mario Bros",
            Id = 1,
            Hash = 1234,
            IsPublic = true,
            LastTimeUpdated = DateTime.Now
        } });
    }

    [HttpGet]
    [Route("/api/cremeworks/entryinfo")]
    public ActionResult<CloudEntryInformation> GetEntryInfo(int token, int entryId)
    {
        return Ok(new CloudEntryInformation()
        {
            Creator = "Super Mario",
            Name = "Super Mario Bros",
            Id = 1,
            Hash = 1234,
            IsPublic = true,
            LastTimeUpdated = DateTime.Now
        });
    }

    [HttpGet]
    [Route("/api/cremeworks/entrydata")]
    public ActionResult<string> GetEntryData(int token, int entryId)
    {
        return Ok("Penis");
    }

    [HttpPost]
    [Route("/api/cremeworks/entrydata")]
    public ActionResult CreateEntry(int token, int entryId, DateTime syncTime, [FromBody] string data)
    {
        return Ok();
    }

    [HttpPost]
    [Route("/api/cremeworks/publish")]
    public ActionResult<int> PublishEntry(int token, string name, bool isPublic, [FromBody] string data)
    {
        return Ok(666);
    }
}
