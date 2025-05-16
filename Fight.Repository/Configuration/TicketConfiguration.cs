using Fight.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Repository.Configuration
{
	public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
	{
		public void Configure(EntityTypeBuilder<Ticket> builder)
		{
			builder.HasOne(p => p.Booking)
				.WithMany()
				.HasForeignKey(x=>x.BookingId)
				.OnDelete(DeleteBehavior.NoAction);
			;
			builder.HasOne(p=>p.Flight)
				.WithMany()
				.HasForeignKey(x=>x.FlightId)
				.OnDelete(DeleteBehavior.NoAction);
			;
			builder.HasOne(x=>x.Destination)
				.WithMany()
				.HasForeignKey(x=>x.DestinationId)
				.OnDelete(DeleteBehavior.NoAction);
			;
		}
	}
}
