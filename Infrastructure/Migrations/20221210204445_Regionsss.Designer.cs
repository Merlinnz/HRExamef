﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221210204445_Regionsss")]
    partial class Regionsss
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Countries", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CountryId"));

                    b.Property<string>("CountryName")
                        .HasColumnType("text");

                    b.Property<int>("RegionId")
                        .HasColumnType("integer");

                    b.Property<int?>("RegionsRegionId")
                        .HasColumnType("integer");

                    b.HasKey("CountryId");

                    b.HasIndex("RegionId")
                        .IsUnique();

                    b.HasIndex("RegionsRegionId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Domain.Entities.Locations", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LocationId"));

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<int?>("CountriesCountryId")
                        .HasColumnType("integer");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("PostalCode")
                        .HasColumnType("text");

                    b.Property<string>("StateProvince")
                        .HasColumnType("text");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("text");

                    b.HasKey("LocationId");

                    b.HasIndex("CountriesCountryId");

                    b.HasIndex("CountryId")
                        .IsUnique();

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Domain.Entities.Regions", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RegionId"));

                    b.Property<string>("RegionName")
                        .HasColumnType("text");

                    b.HasKey("RegionId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Domain.Entities.Countries", b =>
                {
                    b.HasOne("Domain.Entities.Regions", "Region")
                        .WithOne("Countries")
                        .HasForeignKey("Domain.Entities.Countries", "RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Regions", null)
                        .WithMany("Country")
                        .HasForeignKey("RegionsRegionId");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Domain.Entities.Locations", b =>
                {
                    b.HasOne("Domain.Entities.Countries", null)
                        .WithMany("Locationss")
                        .HasForeignKey("CountriesCountryId");

                    b.HasOne("Domain.Entities.Countries", "Country")
                        .WithOne("Locations")
                        .HasForeignKey("Domain.Entities.Locations", "CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Domain.Entities.Countries", b =>
                {
                    b.Navigation("Locations")
                        .IsRequired();

                    b.Navigation("Locationss");
                });

            modelBuilder.Entity("Domain.Entities.Regions", b =>
                {
                    b.Navigation("Countries")
                        .IsRequired();

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}
