using Fight.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Core.ISpecifIcation
{
	public class FlightWithSpecForCountAsync : BaseSpecification<FlightModel>
	{
		public FlightWithSpecForCountAsync(FlightSpecParams Params) : base(p=>
		(!string.IsNullOrEmpty(Params.fromAirport) || p.FromAirport.Name == Params.fromAirport)
		&&
		(!string.IsNullOrEmpty(Params.toAirport) || p.ToAirport.Name == Params.toAirport)
		)
		{
			
		}
	}
}
