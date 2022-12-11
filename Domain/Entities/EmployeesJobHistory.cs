namespace Domain.Entities;

public class EmployeesJobHistory
{
    public int EmployeeId { get; set; }
    public Employees Employees { get; set; }

    public int Id { get; set; }
    public JobHistory JobHistory { get; set; }
}
