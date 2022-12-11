namespace Domain.Dtos;

public class GetRegionCountryLocation
{
    // Region
    public int RegionId { get; set; }
    public string? RegionName { get; set; }
    // Country
    public int CountryId { get; set; }
    public string? CountryName { get; set; }
    // Location
    public int LocationId { get; set; }
    public string? StreetAddress { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
    public string? StateProvince { get; set; }
}
