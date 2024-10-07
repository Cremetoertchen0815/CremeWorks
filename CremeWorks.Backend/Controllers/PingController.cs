using Microsoft.AspNetCore.Mvc;

namespace CremeWorks.Backend.Controllers;

[ApiController]
public class PingController : Controller
{
    [HttpGet]
    [Route("/api/cremeworks/ping")]
    public ActionResult Ping() => Ok();
}
