using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightManagement.Infrastructure.Persistence.Configurations
{
    public class ConnectingFlightConfiguration : IEntityTypeConfiguration<ConnectingFlight>
    {
        public void Configure(EntityTypeBuilder<ConnectingFlight> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Destination).IsRequired().HasMaxLength(150);
            builder.Property(x => x.DepartureTime).IsRequired();
            builder.HasOne(x => x.SharedFlight).WithOne(x => x.ConnectingFlight).HasForeignKey<ConnectingFlight>(x => x.SharedFlightId);
        }
    }
}