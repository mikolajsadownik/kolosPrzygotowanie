using KolosPowtórka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Numerics;

namespace KolosPowtórka.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(e => e.IdClient);

            builder.Property(e => e.FirstName).HasMaxLength(120).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(120).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(120).IsRequired();
            builder.Property(e => e.Telephone).HasMaxLength(120).IsRequired();
            builder.Property(e => e.Pesel).HasMaxLength(120).IsRequired();
        }
    }
}
