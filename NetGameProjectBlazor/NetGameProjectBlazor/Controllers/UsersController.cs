using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetGameProjectBlazor.Interfaces;

namespace NetGameProjectBlazor.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly IUserService _userService;

		public UsersController(SignInManager<IdentityUser> signInManager, IUserService userService)
		{
			_signInManager = signInManager;
			_userService = userService;
		}

		[Authorize]
		[HttpPost("logout")]
		public async Task<IActionResult> Logout([FromBody] object empty)
		{
			//{}
			if (empty is not null)
			{
				await _signInManager.SignOutAsync();
			}
			return Ok();
		}


	}
}
