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
	public class FlightConfiguration : IEntityTypeConfiguration<FlightModel>
	{
		public void Configure(EntityTypeBuilder<FlightModel> builder)
		{

			builder.HasMany(x => x.Tickets)
				.WithOne()
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(x => x.FromAirport)
				.WithMany(x => x.DepartingFlights) 
				.HasForeignKey(x => x.FromAirportId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(x => x.ToAirport)
				.WithMany(x => x.ArrivingFlights) 
				.HasForeignKey(x => x.ToAirportId)
				.OnDelete(DeleteBehavior.NoAction);




		}
	}
}
