using Microsoft.AspNetCore.Mvc;
using NetGameProjectBlazor.Interfaces;
using NetGameProjectBlazor.Services;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();

        if (users == null)
        {
            return NotFound();
        }
        return Ok(users);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto?>> GetUserAsync(string id)
    {
        var user = await _userService.GetUserAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }
}