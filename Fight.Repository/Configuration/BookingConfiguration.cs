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
	public class BookingConfiguration : IEntityTypeConfiguration<Booking>
	{
		public void Configure(EntityTypeBuilder<Booking> builder)
		{
;			builder.HasMany(x=>x.Tickets)
				.WithOne()
				.HasForeignKey(x=>x.BookingId);

			builder.HasOne(x => x.Flight)
				.WithMany()
				.HasForeignKey(x => x.FlightId)
				.OnDelete(DeleteBehavior.NoAction);


		}
	}
}
