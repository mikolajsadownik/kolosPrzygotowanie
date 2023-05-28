using KolosPowtórka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KolosPowtórka.Configurations
{
    public class ClientTripConfiguration : IEntityTypeConfiguration<ClientTrip>
    {
        public void Configure(EntityTypeBuilder<ClientTrip> builder)
        {
            builder.ToTable("Client_Trip");

            builder.HasKey(c => new {c.IdClient, c.IdTrip});

            builder.Property(e => e.RegisteredAt).IsRequired();

            builder.Property(e => e.PaymentDate).IsRequired(false);

            builder.HasOne(x => x.Client).WithMany(x => x.ClientTrips).HasForeignKey(x => x.IdClient).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Trip).WithMany(x => x.ClientTrips).HasForeignKey(x => x.IdTrip).OnDelete(DeleteBehavior.Cascade);



        }
    }
}
