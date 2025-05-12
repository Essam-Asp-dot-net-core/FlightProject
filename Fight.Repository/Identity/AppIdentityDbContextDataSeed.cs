using Flight.Core.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Repository.Identity
{
	public static class AppIdentityDbContextDataSeed
	{
		public static async Task SeedUserAsync(UserManager<AppUser> userManager)
		{

			if (!userManager.Users.Any())
			{
				var user = new AppUser()
				{
					DisplayName = "Ahmed Essam",
					Email = "AhmedEssam@gmail.com",
					UserName = "AhmedEssam",
					PhoneNumber = "01554513780",
				};
				await userManager.CreateAsync(user, "Pa$$w0rd");
			}
		}
	}
}
