using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightManagement.Infrastructure.Persistence.Configurations
{
    public class SharedFlightConfiguration : IEntityTypeConfiguration<SharedFlight>
    {
        public void Configure(EntityTypeBuilder<SharedFlight> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.PartnerFlightNumber, fn =>
            {
                fn.Property(p => p.Value).HasColumnName("PartnerFlightNumber").IsRequired().HasMaxLength(10);
            });
            builder.Property(x => x.PartnerCompany).IsRequired().HasMaxLength(100);
            builder.HasOne(x => x.ConnectingFlight).WithOne(x => x.SharedFlight).HasForeignKey<ConnectingFlight>(x => x.SharedFlightId);
        }
    }
}