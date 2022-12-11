namespace Domain.Entities;
using System.ComponentModel.DataAnnotations;
public class Countries
{
    [Key]
    public int CountryId { get; set; }
    public string? CountryName { get; set; }
    public int RegionId { get; set; }   // Region
    public Regions Region { get; set; }

    public Locations Locations { get; set; }

    public virtual List<Locations> Locationss { get; set; }
}
