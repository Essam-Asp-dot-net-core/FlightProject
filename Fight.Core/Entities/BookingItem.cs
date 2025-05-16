using Fight.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Core.Entities
{
	public class BookingItem : BaseEntity
	{
		public int TicketId { get; set; }
		public Ticket Ticket { get; set; }
		public int Quantity { get; set; }
		public decimal Price => Ticket.Price;
		public int BookingId { get; set; }
		public Booking Booking { get; set; }
	}
}
