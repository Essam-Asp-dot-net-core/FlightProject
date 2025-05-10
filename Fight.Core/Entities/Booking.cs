using Fight.Core.Entities;
using Flight.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Fight.Core.Entities
{
	public class Booking : BaseEntity
	{
		public int UserId { get; set; }
		public User User { get; set; }

		public DateTime BookingDate { get; set; }
		public BookingStatus Status { get; set; }

		public ICollection<Ticket> Tickets { get; set; }
		public Payment Payment { get; set; }

	}
}
