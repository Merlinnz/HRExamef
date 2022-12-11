namespace Domain.Dtos;

public class GetJobsDto
{
    public int JobId { get; set; }
    public string? JobTitle { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }
}
