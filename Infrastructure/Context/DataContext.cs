using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Context;



public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {

    }

    //************ Countries Regions Locations ************
    public DbSet<Countries> Countries { get; set; }
    public DbSet<Regions> Regions { get; set; }
    public DbSet<Locations> Locations { get; set; }

    //***************************************************
    public DbSet<JobGrades> JobGrades { get; set; }

    //***************************************************

    public DbSet<Jobs> Jobs { get; set; }
    public DbSet<JobHistory> JobHistories { get; set; }
    public DbSet<Employees> Employees { get; set; }
    public DbSet<Departments> Departments { get; set; }
    
    //****************************************************

    public DbSet<JobsEmployees> JobsEmployees { get; set; }
    public DbSet<JobsJobsHistory> JobsJobsHistories { get; set; }
    public DbSet<EmployeesJobHistory> EmployeesJobHistories { get; set; }

    //****************************************************

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Regions>().HasKey(c =>   c.RegionId );
        modelBuilder.Entity<Countries>().HasKey(l =>   l.CountryId );
        modelBuilder.Entity<Locations>().HasKey(d => d.LocationId);
        modelBuilder.Entity<Employees>().HasKey(dm => dm.ManagerId);
        modelBuilder.Entity<Departments>().HasKey(de => de.DepartmentId);
        modelBuilder.Entity<Departments>().HasKey(dj => dj.DepartmentId);

        modelBuilder.Entity<JobsEmployees>().HasKey(je => new { je.JobId, je.EmployeeId });
        modelBuilder.Entity<JobsJobsHistory>().HasKey(jh => new { jh.JobId, jh.Id });
        modelBuilder.Entity<EmployeesJobHistory>().HasKey(ej => new { ej.EmployeeId, ej.Id });


        modelBuilder.Entity<Regions>()
            .HasOne(c => c.Countries)
            .WithOne(i => i.Region)
            .HasForeignKey<Countries>(c => c.RegionId);

        modelBuilder.Entity<Countries>()
            .HasOne(l => l.Locations)
            .WithOne(o => o.Country)
            .HasForeignKey<Locations>(l => l.CountryId);

        modelBuilder.Entity<Locations>()
            .HasOne(d => d.Departments)
            .WithOne(i => i.Locations)
            .HasForeignKey<Departments>(d => d.LocationId);

        modelBuilder.Entity<Employees>()
            .HasOne(dm => dm.Departments)
            .WithOne(i => i.Employees)
            .HasForeignKey<Departments>(dm => dm.ManagerId);

        modelBuilder.Entity<Departments>()
            .HasOne(de => de.Employees)
            .WithOne(i => i.Departments)
            .HasForeignKey<Employees>(de => de.DepartmentId);

        modelBuilder.Entity<Departments>()
            .HasOne(dj => dj.JobHistory)
            .WithOne(i => i.Departments)
            .HasForeignKey<JobHistory>(dj => dj.DepartmentId);


        modelBuilder.Entity<JobsEmployees>()
            .HasOne<Jobs>(je => je.Jobs)
            .WithMany(i => i.JobsEmployees)
            .HasForeignKey(je => je.JobId);
        modelBuilder.Entity<JobsEmployees>()
            .HasOne<Employees>(je => je.Employees)
            .WithMany(i => i.JobsEmployees)
            .HasForeignKey(je => je.EmployeeId);


        modelBuilder.Entity<JobsJobsHistory>()
            .HasOne<Jobs>(jh => jh.Jobs)
            .WithMany(i => i.JobsJobsHistories)
            .HasForeignKey(jh => jh.JobId);
        modelBuilder.Entity<JobsJobsHistory>()
            .HasOne<JobHistory>(jh => jh.JobHistory)
            .WithMany(i => i.JobsJobsHistories)
            .HasForeignKey(jh => jh.Id);


        modelBuilder.Entity<EmployeesJobHistory>()
            .HasOne<Employees>(ej => ej.Employees)
            .WithMany(i => i.EmployeesJobHistories)
            .HasForeignKey(ej => ej.EmployeeId);
        modelBuilder.Entity<EmployeesJobHistory>()
            .HasOne<JobHistory>(ej => ej.JobHistory)
            .WithMany(i => i.EmployeesJobHistories)
            .HasForeignKey(ej => ej.Id);    
    }
}