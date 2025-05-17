using Flight.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Core.Entities
{
	public class Ticket : BaseEntity
	{
		public int BookingId { get; set; }
		public Booking Booking { get; set; }

		public int FlightId { get; set; }
		public Flight Flight { get; set; }

		public string PassengerName { get; set; }
		public string SeatNumber { get; set; }
		public string Class { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}



