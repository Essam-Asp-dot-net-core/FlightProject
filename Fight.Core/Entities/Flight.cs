using Flight.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Core.Entities
{
    public class Flight : BaseEntity
    {
        public string FlightNumber { get; set; }

        public int DepartureAirPortId { get; set; }
        public AirPort DepartureAirPort { get; set; }

        public int ArrivalAirPortId { get; set; }
        public AirPort ArrivalAirPort { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public int AirplaneId { get; set; }
        public Airplane Airplane { get; set; }

        public decimal Price { get; set; }
        public string Status { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}


