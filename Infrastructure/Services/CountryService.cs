using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CountryService
{
    private readonly DataContext _context;

    public CountryService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetCountriesDto>>> GetCountries()
    {
        var list = await _context.Countries.Select(t => new GetCountriesDto()
        {
            CountryId = t.CountryId,
            CountryName = t.CountryName
        }).ToListAsync();
        return new Response<List<GetCountriesDto>>(list);
    }

    public async Task<Response<AddCountriesDto>> AddCountry(AddCountriesDto country)
    {
        var newCountries = new Countries()
        {
            CountryName = country.CountryName,
            RegionId = country.RegionId
        };
        _context.Countries.Add(newCountries);
        await _context.SaveChangesAsync();
        return new Response<AddCountriesDto>(country);
    }

    public async Task<Response<AddCountriesDto>> UpdateCountry(AddCountriesDto country)
    {
        var find = await _context.Countries.FindAsync(country.CountryId);
        find.CountryName = country.CountryName;
        find.RegionId = country.RegionId;
        await _context.SaveChangesAsync();
        return new Response<AddCountriesDto>(country);
    }

    public async Task<Response<string>> DeleteCountry(int id)
    {
        var find = await _context.Countries.FindAsync(id);
        _context.Countries.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Country has been Deleted");
    }

    // Method to Get Full Inforamtions

    public async Task<Response<List<GetRegionCountryLocation>>> GetFullInformation()
    {
        var list = await (from r in _context.Regions
        join c in _context.Countries on r.RegionId equals c.RegionId
        join l in _context.Locations on c.CountryId equals l.CountryId
        select new GetRegionCountryLocation()
        {
            RegionId = r.RegionId,
            RegionName = r.RegionName,
            CountryId = c.CountryId,
            CountryName = c.CountryName,
            LocationId = l.LocationId,
            StreetAddress = l.StreetAddress,
            PostalCode = l.PostalCode,
            City = l.City,
            StateProvince = l.StateProvince
        }).ToListAsync();
        return new Response<List<GetRegionCountryLocation>>(list);
    }
}
