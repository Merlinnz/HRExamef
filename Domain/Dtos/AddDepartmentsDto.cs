namespace Domain.Dtos;

public class AddDepartmentsDto
{
    public int DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public int ManagerId { get; set; } // Manager
    public int LocationId { get; set; } // Location
}
