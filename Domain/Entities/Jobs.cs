namespace Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class Jobs
{
    [Key]
    public int JobId { get; set; }
    public string? JobTitle { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }

    public List<JobsEmployees> JobsEmployees { get; set; }

    public List<JobsJobsHistory> JobsJobsHistories { get; set; }
    
}
