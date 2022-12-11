namespace Domain.Entities;
using System.ComponentModel.DataAnnotations;
public class Departments
{
    [Key]
    public int DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public int ManagerId { get; set; } // Manager
    public Employees Employees { get; set; }
    public int LocationId { get; set; } // Location
    public Locations Locations { get; set; }

    public JobHistory JobHistory { get; set; }
    
}
