using Fight.Core.Entities;

namespace FlightProject.DTOs
{
	public class FlightModelDTOs
	{
		public string FlightNumber { get; set; }
		public int FromAirportId { get; set; }
		public int ToAirportId { get; set; }
		public DateTime DepartureTime { get; set; }
		public DateTime ArrivalTime { get; set; }
		public int AirplaneId { get; set; }

		public decimal Price { get; set; }
		public string Status { get; set; }
		public string Tickets { get; set; }

	}
}
