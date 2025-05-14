using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject.DTOs
{
    public class FlightDto
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public int FromAirportId { get; set; }
        public string FromAirportName { get; set; }
        public int ToAirportId { get; set; }
        public string ToAirportName { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AirplaneId { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
    }
}
