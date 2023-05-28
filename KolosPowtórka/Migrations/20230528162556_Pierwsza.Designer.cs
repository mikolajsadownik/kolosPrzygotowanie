﻿// <auto-generated />
using System;
using KolosPowtórka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KolosPowtórka.Migrations
{
    [DbContext(typeof(MasterContext))]
    [Migration("20230528162556_Pierwsza")]
    partial class Pierwsza
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KolosPowtórka.Models.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("IdClient");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("KolosPowtórka.Models.ClientTrip", b =>
                {
                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdTrip")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RegisteredAt")
                        .HasColumnType("datetime2");

                    b.HasKey("IdClient", "IdTrip");

                    b.HasIndex("IdTrip");

                    b.ToTable("Client_Trip", (string)null);
                });

            modelBuilder.Entity("KolosPowtórka.Models.Country", b =>
                {
                    b.Property<int>("IdCountry")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCountry"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("IdCountry");

                    b.ToTable("Country", (string)null);
                });

            modelBuilder.Entity("KolosPowtórka.Models.CountryTrip", b =>
                {
                    b.Property<int>("IdCountry")
                        .HasColumnType("int");

                    b.Property<int>("IdTrip")
                        .HasColumnType("int");

                    b.HasKey("IdCountry", "IdTrip");

                    b.HasIndex("IdTrip");

                    b.ToTable("Country_Trip", (string)null);
                });

            modelBuilder.Entity("KolosPowtórka.Models.Trip", b =>
                {
                    b.Property<int>("IdTrip")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTrip"));

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(220)
                        .HasColumnType("nvarchar(220)");

                    b.Property<int>("MaxPeople")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("IdTrip");

                    b.ToTable("Trip", (string)null);
                });

            modelBuilder.Entity("KolosPowtórka.Models.ClientTrip", b =>
                {
                    b.HasOne("KolosPowtórka.Models.Client", "Client")
                        .WithMany("ClientTrips")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KolosPowtórka.Models.Trip", "Trip")
                        .WithMany("ClientTrips")
                        .HasForeignKey("IdTrip")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("KolosPowtórka.Models.CountryTrip", b =>
                {
                    b.HasOne("KolosPowtórka.Models.Country", "Country")
                        .WithMany("CountryTrips")
                        .HasForeignKey("IdCountry")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KolosPowtórka.Models.Trip", "Trip")
                        .WithMany("CountryTrips")
                        .HasForeignKey("IdTrip")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("KolosPowtórka.Models.Client", b =>
                {
                    b.Navigation("ClientTrips");
                });

            modelBuilder.Entity("KolosPowtórka.Models.Country", b =>
                {
                    b.Navigation("CountryTrips");
                });

            modelBuilder.Entity("KolosPowtórka.Models.Trip", b =>
                {
                    b.Navigation("ClientTrips");

                    b.Navigation("CountryTrips");
                });
#pragma warning restore 612, 618
        }
    }
}
