using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject.DTOs
{
    public class FlightDto
    {
        public string FlightNumber { get; set; }

        public int DepartureAirPortId { get; set; }
        public string DepartureAirPortName { get; set; }

        public int ArrivalAirPortId { get; set; }
        public string ArrivalAirPortName { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public int AirplaneId { get; set; }
        public string AirplaneModel { get; set; }

        public decimal Price { get; set; }
        public string Status { get; set; }
        public int Id { get; internal set; }
    }
}
