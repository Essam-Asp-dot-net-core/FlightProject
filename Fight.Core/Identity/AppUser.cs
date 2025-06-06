﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Core.Identity
{
	public class AppUser : IdentityUser 
	{
		public string DisplayName { get; set; }
		public string Role { get; set; }
		public Address Address { get; set; }
	}
}
