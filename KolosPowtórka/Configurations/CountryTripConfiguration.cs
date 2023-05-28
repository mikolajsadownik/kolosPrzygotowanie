using KolosPowtórka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KolosPowtórka.Configurations
{
    public class CountryTripConfiguration : IEntityTypeConfiguration<CountryTrip>
    {
        public void Configure(EntityTypeBuilder<CountryTrip> builder)
        {
            builder.ToTable("Country_Trip");

            builder.HasKey(c => new { c.IdCountry, c.IdTrip });

            builder.HasOne(x => x.Country).WithMany(x => x.CountryTrips).HasForeignKey(x => x.IdCountry).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Trip).WithMany(x => x.CountryTrips).HasForeignKey(x => x.IdTrip).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
