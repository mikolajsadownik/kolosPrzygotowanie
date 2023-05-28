using KolosPowtórka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KolosPowtórka.Configurations
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.ToTable("Trip");

            builder.HasKey(c => c.IdTrip);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(120);

            builder.Property(e => e.Description).IsRequired().HasMaxLength(220);

            builder.Property(e => e.DateFrom).IsRequired();

            builder.Property(e => e.DateTo).IsRequired();

            builder.Property(e => e.MaxPeople).IsRequired();
        }
    }
}
