using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightManagement.Infrastructure.Persistence.Configurations
{
    public class AirportConfigurations : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Country).IsRequired().HasMaxLength(100);
            builder.Property(x => x.City).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.OwnsOne(x => x.Code, cb =>
            {
                cb.Property(p => p.Value).HasColumnName("Code").IsRequired().HasMaxLength(10);
            });
        }
    }
}