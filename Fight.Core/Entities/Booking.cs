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
		public int FlightId { get; set; }
		public FlightModel FlightTrip { get; set; }
		public string PassengerName { get; set; }
		public string Email { get; set; }
		public int SeatCount { get; set; }
		public DateTime BookingDate { get; set; } = DateTime.UtcNow;
		public BookingStatus Status { get; set; } = BookingStatus.Pending;
		public ICollection<Ticket> Tickets { get; set; }
		//public Payment Payment { get; set; }
		public List<BookingItem> Items { get; set; } = new();
		public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
		public decimal TotalPriceForBooking { get; set; }
	}
}

