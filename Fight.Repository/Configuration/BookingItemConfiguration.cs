using Flight.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Repository.Configuration
{
	public class BookingItemConfiguration : IEntityTypeConfiguration<BookingItem>
	{
		public void Configure(EntityTypeBuilder<BookingItem> builder)
		{
			builder.HasOne(x => x.Booking)
				.WithMany()
				.HasForeignKey(x=>x.BookingId)
				.OnDelete(DeleteBehavior.NoAction);
			;

			builder.HasOne(x => x.Ticket)
				.WithOne()
				.OnDelete(DeleteBehavior.NoAction);
			;
		
			builder.HasOne(x=>x.Ticket)
				.WithMany()
				.HasForeignKey(x=>x.TicketId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
