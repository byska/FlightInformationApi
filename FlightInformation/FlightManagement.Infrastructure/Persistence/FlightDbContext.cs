using System;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightManagement.Infrastructure.Persistence
{
    public class FlightDbContext : DbContext, IUnitOfWork
    {
        public FlightDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Airport> Airports => Set<Airport>();
        public DbSet<Flight> Flights => Set<Flight>();
        public DbSet<VehicleType> VehicleTypes => Set<VehicleType>();
        public DbSet<SharedFlight> SharedFlights => Set<SharedFlight>();
        public DbSet<ConnectingFlight> ConnectingFlights => Set<ConnectingFlight>();
        public DbSet<FlightRoute> FlightRoutes => Set<FlightRoute>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FlightDbContext).Assembly);
        }
    }
}