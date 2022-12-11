namespace Domain.Entities;

public class JobHistory
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int JobId { get; set; } // Jobs
    public int DepartmentId { get; set; } // Department
    public Departments Departments { get; set; } // Departments

    public List<JobsJobsHistory> JobsJobsHistories { get; set; }
    public List<EmployeesJobHistory> EmployeesJobHistories { get; set; }
}
