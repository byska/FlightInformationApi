using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightManagement.Infrastructure.Persistence.Configurations
{
    public class FlightRouteConfiguration : IEntityTypeConfiguration<FlightRoute>
    {
        public void Configure(EntityTypeBuilder<FlightRoute> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.SourceAirport).WithMany().HasForeignKey(x => x.SourceAirportId);
            builder.HasOne(x => x.DestinationAirport).WithMany().HasForeignKey(x => x.DestinationAirportId);

        }
    }
}