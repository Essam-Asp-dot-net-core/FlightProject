//using Fight.Core.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Flight.Repository.Configuration
//{
//	public class AirPortConfiguration : IEntityTypeConfiguration<AirPort>
//	{
//		public void Configure(EntityTypeBuilder<AirPort> builder)
//		{

//			builder.HasOne(x => x.FromAirport)
//			.WithMany()
//			.HasForeignKey(x => x.FromAirportId)
//			.OnDelete(DeleteBehavior.NoAction);
//			;
//		}
//	}
//}
