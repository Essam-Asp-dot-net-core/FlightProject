using Fight.Core.Entities;
using Flight.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Repository.MyFlightDbContext
{
	public class FlightDbContext : DbContext
	{
		public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}
		//public DbSet<AirPort> AirPorts { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<BookingItem> BookingItems { get; set; }
		public DbSet<Destination> Destinations { get; set; }
		public DbSet<FlightModel> Flights { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
