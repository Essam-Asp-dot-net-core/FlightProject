using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Core.Entities
{
	public class Airplane : BaseEntity
	{
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int Capacity { get; set; }
		public string RegistrationNumber { get; set; }

		public ICollection<Flight> Flights { get; set; }

	}
}
