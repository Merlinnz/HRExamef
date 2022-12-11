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
    [Migration("20221211074026_Complete")]
    partial class Complete
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

            modelBuilder.Entity("Domain.Entities.Departments", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .HasColumnType("text");

                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    b.Property<int>("ManagerId")
                        .HasColumnType("integer");

                    b.HasKey("DepartmentId");

                    b.HasIndex("LocationId")
                        .IsUnique();

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Domain.Entities.Employees", b =>
                {
                    b.Property<int>("ManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ManagerId"));

                    b.Property<int>("CommissionPct")
                        .HasColumnType("integer");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("JobId")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("Salary")
                        .HasColumnType("integer");

                    b.HasKey("ManagerId");

                    b.HasIndex("DepartmentId")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Domain.Entities.EmployeesJobHistory", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.HasKey("EmployeeId", "Id");

                    b.HasIndex("Id");

                    b.ToTable("EmployeesJobHistories");
                });

            modelBuilder.Entity("Domain.Entities.JobGrades", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("GradeLevel")
                        .HasColumnType("text");

                    b.Property<int>("HighestSalary")
                        .HasColumnType("integer");

                    b.Property<int>("LowestSalary")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("JobGrades");
                });

            modelBuilder.Entity("Domain.Entities.JobHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("JobId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId")
                        .IsUnique();

                    b.ToTable("JobHistories");
                });

            modelBuilder.Entity("Domain.Entities.Jobs", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("JobId"));

                    b.Property<string>("JobTitle")
                        .HasColumnType("text");

                    b.Property<int>("MaxSalary")
                        .HasColumnType("integer");

                    b.Property<int>("MinSalary")
                        .HasColumnType("integer");

                    b.HasKey("JobId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Domain.Entities.JobsEmployees", b =>
                {
                    b.Property<int>("JobId")
                        .HasColumnType("integer");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.HasKey("JobId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("JobsEmployees");
                });

            modelBuilder.Entity("Domain.Entities.JobsJobsHistory", b =>
                {
                    b.Property<int>("JobId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.HasKey("JobId", "Id");

                    b.HasIndex("Id");

                    b.ToTable("JobsJobsHistories");
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

            modelBuilder.Entity("Domain.Entities.Departments", b =>
                {
                    b.HasOne("Domain.Entities.Locations", "Locations")
                        .WithOne("Departments")
                        .HasForeignKey("Domain.Entities.Departments", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locations");
                });

            modelBuilder.Entity("Domain.Entities.Employees", b =>
                {
                    b.HasOne("Domain.Entities.Departments", "Departments")
                        .WithOne("Employees")
                        .HasForeignKey("Domain.Entities.Employees", "DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departments");
                });

            modelBuilder.Entity("Domain.Entities.EmployeesJobHistory", b =>
                {
                    b.HasOne("Domain.Entities.Employees", "Employees")
                        .WithMany("EmployeesJobHistories")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.JobHistory", "JobHistory")
                        .WithMany("EmployeesJobHistories")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");

                    b.Navigation("JobHistory");
                });

            modelBuilder.Entity("Domain.Entities.JobHistory", b =>
                {
                    b.HasOne("Domain.Entities.Departments", "Departments")
                        .WithOne("JobHistory")
                        .HasForeignKey("Domain.Entities.JobHistory", "DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departments");
                });

            modelBuilder.Entity("Domain.Entities.JobsEmployees", b =>
                {
                    b.HasOne("Domain.Entities.Employees", "Employees")
                        .WithMany("JobsEmployees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Jobs", "Jobs")
                        .WithMany("JobsEmployees")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");

                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("Domain.Entities.JobsJobsHistory", b =>
                {
                    b.HasOne("Domain.Entities.JobHistory", "JobHistory")
                        .WithMany("JobsJobsHistories")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Jobs", "Jobs")
                        .WithMany("JobsJobsHistories")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobHistory");

                    b.Navigation("Jobs");
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

            modelBuilder.Entity("Domain.Entities.Departments", b =>
                {
                    b.Navigation("Employees")
                        .IsRequired();

                    b.Navigation("JobHistory")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Employees", b =>
                {
                    b.Navigation("EmployeesJobHistories");

                    b.Navigation("JobsEmployees");
                });

            modelBuilder.Entity("Domain.Entities.JobHistory", b =>
                {
                    b.Navigation("EmployeesJobHistories");

                    b.Navigation("JobsJobsHistories");
                });

            modelBuilder.Entity("Domain.Entities.Jobs", b =>
                {
                    b.Navigation("JobsEmployees");

                    b.Navigation("JobsJobsHistories");
                });

            modelBuilder.Entity("Domain.Entities.Locations", b =>
                {
                    b.Navigation("Departments")
                        .IsRequired();
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
