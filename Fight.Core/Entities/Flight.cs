using Fight.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Fight.Core.Entities
{
	public class Flight : BaseEntity
	{
		public string FlightNumber { get; set; }

		public int FromAirportId { get; set; }
		public AirPort FromAirport { get; set; }

		public int ToAirportId { get; set; }
		public AirPort ToAirport { get; set; }

		public DateTime DepartureTime { get; set; }
		public DateTime ArrivalTime { get; set; }

		public int AirplaneId { get; set; }
		public Airplane Airplane { get; set; }

		public decimal Price { get; set; }
		public string Status { get; set; }

		public ICollection<Ticket> Tickets { get; set; }

	}
}



