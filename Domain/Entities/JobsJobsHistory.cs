namespace Domain.Entities;

public class JobsJobsHistory
{
    public int JobId { get; set; }
    public Jobs Jobs { get; set; }

    public int Id { get; set; }
    public JobHistory JobHistory { get; set; }
}
