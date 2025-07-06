using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightManagement.Infrastructure.Persistence.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(f => f.Id);
            builder.OwnsOne(f => f.FlightNumber, fn =>
        {
            fn.Property(p => p.Value)
              .HasColumnName("FlightNumber")
              .IsRequired().HasMaxLength(10);
        });
            builder.Property(x => x.FlightDateTime).IsRequired();

            builder.OwnsOne(f => f.Duration, d =>
            {
                d.Property(p => p.Value)
                 .HasColumnName("Duration")
                 .IsRequired();
            });
            builder.Property(x => x.Distance).IsRequired();
            builder.HasOne(x => x.FlightRoute).WithMany().HasForeignKey(x => x.FlightRouteId);
            builder.HasOne(x => x.VehicleType).WithMany().HasForeignKey(x => x.VehicleTypeId);
            builder.HasOne(x => x.SharedFlight).WithOne(x => x.Flight).HasForeignKey<SharedFlight>(x => x.FlightId);

        }
    }
}