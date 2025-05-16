using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Core.ISpecifIcation
{
	public class FlightSpecParams
	{
		public string Sort { get; set; } = string.Empty;
		public string fromAirport { get; set; } = string.Empty;
		public string toAirport { get; set; } = string.Empty;
		public int count { get; set; }
		private int pageSize = 5;

		public int PageSize
		{
			get { return pageSize; }
			set { pageSize = value > 10 ? 10 : value; }
		}
		public int PageIndex { get; set; } = 1;
	}
}
