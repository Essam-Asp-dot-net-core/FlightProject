using Flight.Core.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Core.Services
{
	public interface ITokenServices
	{
		Task<string>CreateTokenAsync(AppUser User , UserManager<AppUser> userManager);
	}
}
