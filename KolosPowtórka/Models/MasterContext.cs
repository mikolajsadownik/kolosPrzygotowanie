using KolosPowtórka.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace KolosPowtórka.Models
{
    public class MasterContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientTrip> ClientTrips { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<CountryTrip> CountryTrips{ get; set; }

        public DbSet<Trip> Trips { get; set; }

        public MasterContext() { }

        public MasterContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new ClientTripConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new CountryTripConfiguration());
            modelBuilder.ApplyConfiguration(new TripConfiguration());
        }
    }
}
