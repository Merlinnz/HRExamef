namespace Domain.Dtos;

public class GetEmployeesDto
{
    public int EmployeeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }
    public int JobId { get; set; }
    public int Salary { get; set; }
    public int CommissionPct { get; set; }  // CommissionPatrolCraftTraining
    public int ManagerId { get; set; } // Manager
    public int DepartmentId { get; set; } // Department
}
