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
	public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
	{
		public void Configure(EntityTypeBuilder<Destination> builder)
		{
			builder.HasMany(x => x.Tickets)
				.WithOne()
				.OnDelete(DeleteBehavior.NoAction);
			;
		}
	}
}
