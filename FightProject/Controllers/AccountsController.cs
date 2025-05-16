using Flight.Core.Identity;
using Flight.Core.Services;
using FlightProject.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FlightProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountsController : ControllerBase
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly ITokenServices _tokenServices;

		public AccountsController(UserManager<AppUser> userManager , SignInManager<AppUser> signInManager ,ITokenServices tokenServices )
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenServices = tokenServices;
		}
		//Register
		[HttpPost("Register")]
		public async Task<ActionResult<UserDTO>> Register(RegisterDTO model)
		{
			var user = new AppUser()
			{
				DisplayName = model.DisplayName,
				Email = model.Email,
				UserName = model.Email.Split('@')[0],
				PhoneNumber = model.PhoneNumber,
				Role = "User"
			};

			var Result = await _userManager.CreateAsync(user, model.Password);
			if (!Result.Succeeded)
			{
				return BadRequest();
			}

			var ReturnedUser = new UserDTO()
			{
				Email = model.Email,
				DisplayName = model.DisplayName,
				Role = "User",
				Token = await _tokenServices.CreateTokenAsync(user, _userManager)
			};

			return Ok(ReturnedUser);
		}

		//Login
		[HttpPost("Login")]
		public async Task<ActionResult<UserDTO>> Login(LoginDTO model)
		{
			var User = await _userManager.FindByEmailAsync(model.Email);
			if (User is null)
				return Unauthorized();
			var Result =  await _signInManager.CheckPasswordSignInAsync(User , model.Password , false);
				if(!Result.Succeeded)
					return BadRequest();
			var ReturnedUser = new UserDTO()
			{
				Email = User.Email,
				DisplayName = User.DisplayName,
				Token = await _tokenServices.CreateTokenAsync(User, _userManager)
			};
			
			return Ok(ReturnedUser);
		}
	}
}