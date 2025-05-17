using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Flight.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flight.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Flight.Core.Entities.Flight> Flights { get; set; }
        public DbSet<AirPort> AirPorts { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // تعديل علاقة Flight مع DepartureAirPort لتفعيل Restrict في حالة الحذف أو التحديث
            modelBuilder.Entity<Flight.Core.Entities.Flight>()
                .HasOne(f => f.DepartureAirPort)
                .WithMany(a => a.DepartingFlights)
                .HasForeignKey(f => f.DepartureAirPortId)
                .OnDelete(DeleteBehavior.Restrict);  // منع الحذف التلقائي عند حذف السجلات المرتبطة

            // تعديل علاقة Flight مع ArrivalAirPort لتفعيل Restrict في حالة الحذف أو التحديث
            modelBuilder.Entity<Flight.Core.Entities.Flight>()
                .HasOne(f => f.ArrivalAirPort)
                .WithMany(a => a.ArrivingFlights)
                .HasForeignKey(f => f.ArrivalAirPortId)
                .OnDelete(DeleteBehavior.Restrict);  // منع الحذف التلقائي عند حذف السجلات المرتبطة
            modelBuilder.Entity<Flight.Core.Entities.Flight>()
           .Property(f => f.Price)
           .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Ticket>()
        .HasOne(t => t.Flight)
        .WithMany(f => f.Tickets)
        .HasForeignKey(t => t.FlightId)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // تعريف العلاقة بين AirPort و DepartingFlights
            modelBuilder.Entity<AirPort>()
                .HasMany(a => a.DepartingFlights)
                .WithOne(f => f.DepartureAirPort)
                .HasForeignKey(f => f.DepartureAirPortId)
                .OnDelete(DeleteBehavior.Restrict);

            // تعريف العلاقة بين AirPort و ArrivingFlights
            modelBuilder.Entity<AirPort>()
                .HasMany(a => a.ArrivingFlights)
                .WithOne(f => f.ArrivalAirPort)
                .HasForeignKey(f => f.ArrivalAirPortId)
                .OnDelete(DeleteBehavior.Restrict);

        }


    }
}
