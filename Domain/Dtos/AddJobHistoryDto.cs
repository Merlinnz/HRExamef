namespace Domain.Dtos;

public class AddJobHistoryDto
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int JobId { get; set; } // Jobs
    public int DepartmentId { get; set; } // Department
}
