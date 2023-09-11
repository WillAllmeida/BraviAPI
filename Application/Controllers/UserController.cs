using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<ContactController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<ContactController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var result = await _userService.GetUserList();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var result = await _userService.CreateUser(request);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        var result = await _userService.DeleteUser(id);

        if (!result)
        {
            //TODO fix status
            return BadRequest();
        }

        return Ok(result);
    }
}
