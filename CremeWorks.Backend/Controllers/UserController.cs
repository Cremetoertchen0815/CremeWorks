using CremeWorks.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace CremeWorks.Backend.Controllers;

[ApiController]
[Route("/api/cremeworks/user")]
public class UserController(UserService userService) : Controller
{
    [HttpGet]
    public ActionResult Validate(int token) => userService.ValidateSession(token) ? Ok() : Unauthorized();

    [HttpPost]
    public async Task<ActionResult> Create(string username, string password)
    {
        await userService.CreateUser(username, password);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult<int>> Logon(string username, string password)
    {
        var token = await userService.CreateSessionAsync(username, password);
        return token.HasValue ? Ok(token.Value) : Unauthorized();
    }
}
