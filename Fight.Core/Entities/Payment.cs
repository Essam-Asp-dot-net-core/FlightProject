using Flight.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Core.Entities
{
	public class Payment : BaseEntity
	{
		public int BookingId { get; set; }
		public Booking Booking { get; set; }

		public decimal Amount { get; set; }
		public DateTime PaidAt { get; set; }
		public string PaymentMethod { get; set; }
		public string Status { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}

