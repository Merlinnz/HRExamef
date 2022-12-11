namespace Domain.Entities;

public class JobsEmployees
{
    public int JobId { get; set; }
    public Jobs Jobs { get; set; }

    public int EmployeeId { get; set; }
    public Employees Employees { get; set; }
}
