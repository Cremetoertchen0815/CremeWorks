using Microsoft.AspNetCore.Mvc;

namespace CremeWorks.Backend.Controllers;

[ApiController]
[Route("/api/cremeworks/user")]
public class UserController : Controller
{
    [HttpGet]
    public ActionResult Validate(int tokens)
    {
        return Ok();
    }

    [HttpPost]
    public ActionResult Create(string username, string password)
    {
        return Ok(1234);
    }

    [HttpPut]
    public ActionResult<int> Logon(string username, string password)
    {
        return Ok(1234);
    }
}
