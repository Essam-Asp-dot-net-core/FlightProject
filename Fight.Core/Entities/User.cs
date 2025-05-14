using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Core.Entities
{
	public class User : BaseEntity
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public string PhoneNumber { get; set; }
		public string Role { get; set; } // Passenger, Admin
		public DateTime CreatedAt { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

        public ICollection<Booking> Bookings { get; set; }
	}
}



