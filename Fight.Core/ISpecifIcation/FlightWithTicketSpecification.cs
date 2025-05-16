using Fight.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Core.ISpecifIcation
{
	public class FlightWithTicketSpecification : BaseSpecification<FlightModel>
	{
		public FlightWithTicketSpecification(FlightSpecParams Params) : base(
			p=>
			(!string.IsNullOrEmpty(Params.fromAirport) || p.FromAirport.Name == Params.fromAirport)
			&&
			(!string.IsNullOrEmpty(Params.toAirport) || p.ToAirport.Name == Params.toAirport)
			)
		{
			InCludes.Add(p => p.Tickets);
			if (!string.IsNullOrEmpty(Params.Sort))
			{
				switch(Params.Sort)
				{
					case "PriceAsc":
						AddOrderBy(x=>x.Price);
						break;
					case "PriceDesc":
						AddOrderByDescending(x => x.Price);
						break;
					default:
						AddOrderBy(x=>x.FlightNumber);
						break;

				}
			}

			ApplyPagination(Params.PageSize * (Params.PageIndex-1) , Params.PageSize);
		}

		public FlightWithTicketSpecification(int id):base(p=>p.Id == id)
		{
			InCludes.Add(p => p.Tickets);
		}
	}
}
