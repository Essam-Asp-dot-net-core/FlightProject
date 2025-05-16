using Fight.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Core.Entities
{
	public class Destination : BaseEntity
	{
		public string Name { get; set; }
		public string Location { get; set; }
		public string Discription { get; set; }
		public decimal Price { get; set; }
		public double Rating { get; set; }
		public string ImageUrl { get; set; }
		public List<Ticket> Tickets { get; set; }
	}
}
