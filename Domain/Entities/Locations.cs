namespace Domain.Entities;
using System.ComponentModel.DataAnnotations;
public class Locations
{
    [Key]
    public int LocationId { get; set; }
    public string? StreetAddress { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
    public string? StateProvince { get; set; }
    public int CountryId { get; set; }  //Countries
    public Countries Country { get; set; } 

    public Departments Departments { get; set; }

}
