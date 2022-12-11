namespace Domain.Entities;

public class JobGrades
{
    public int Id { get; set; }
    public string? GradeLevel { get; set; }
    public int LowestSalary { get; set; }
    public int HighestSalary { get; set; }
}
