using Flight.Core.Identity;
using Flight.Core.Services;
using Flight.Repository.Identity;
using Flight.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FlightProject.Extentions
{
	public static class IdentityServicesExtention
	{
		public static IServiceCollection AddIdentityServices(this IServiceCollection Services , IConfiguration configuration)
		{
			Services.AddScoped(typeof(ITokenServices), typeof(TokenServices));
			Services.AddIdentity<AppUser, IdentityRole>()
			.AddEntityFrameworkStores<AppIdentityDbContext>();
			Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(Option=>
				{
					Option.TokenValidationParameters = new TokenValidationParameters()
					{
						ValidateIssuer = true,
						ValidIssuer = configuration["JWT:ValidatedIssure"],
						ValidateAudience = true,
						ValidAudience = configuration["JWT:ValidatedIssure"],
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:AuthKey"]))
					};
				});

			return Services;
		}
	}
}
