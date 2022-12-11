namespace Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class Regions
{
    [Key]
    public int RegionId { get; set; }
    public string? RegionName { get; set; }
    public Countries Countries { get; set; }

    public virtual List<Countries> Country { get; set; }
}
