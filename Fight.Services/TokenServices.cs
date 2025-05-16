using Flight.Core.Identity;
using Flight.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Services
{
	public class TokenServices : ITokenServices
	{
		private readonly IConfiguration _configuration;

		public TokenServices(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public async Task<string> CreateTokenAsync(AppUser User , UserManager<AppUser> userManager)
		{
			
			
			var AuthClaims = new List<Claim>()
			{
				new Claim(ClaimTypes.GivenName , User.DisplayName),
				new Claim(ClaimTypes.Email, User.Email),
				
			};
			var UserRole = await userManager.GetRolesAsync(User);
			foreach (var role in UserRole)
			{
				AuthClaims.Add(new Claim(ClaimTypes.Role, role));
			}
			var AuthKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:AuthKey"]));

			var token = new JwtSecurityToken(
			
				issuer:_configuration["JWT:ValidatedIssure"],
				audience: _configuration["JWT:ValidatedAudiance"],
				expires : DateTime.Now.AddDays(double.Parse(_configuration["JWT:Expired"])),
				claims : AuthClaims,
				signingCredentials:new SigningCredentials(AuthKey , SecurityAlgorithms.HmacSha256Signature)
				);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
