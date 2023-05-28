using KolosPowtórka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KolosPowtórka.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");

            builder.HasKey(e => e.IdCountry);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(120);
        }
    }
}
