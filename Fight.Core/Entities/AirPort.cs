using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Core.Entities
{
	public class AirPort : BaseEntity
	{
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Code { get; set; }

        public ICollection<Flight> DepartingFlights { get; set; }
        public ICollection<Flight> ArrivingFlights { get; set; }
    }
}
