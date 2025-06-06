﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight.Core.Entities
{
	public class AirPort : BaseEntity
	{
		public string Name { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public string Code { get; set; }
		public int DepartingFlightsId { get; set; }
		public ICollection<FlightModel> DepartingFlights { get; set; }
		public int ArrivingFlightsId { get; set; }
		public ICollection<FlightModel> ArrivingFlights { get; set; }

	}
}
