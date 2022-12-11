using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class LocationService
{
    private readonly DataContext _context;

    public LocationService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetLocationsDto>>> GetLocations()
    {
        var list = await _context.Locations.Select(t => new GetLocationsDto()
        {
            LocationId = t.LocationId,
            StreetAddress = t.StreetAddress,
            PostalCode = t.PostalCode,
            City = t.City,
            StateProvince = t.StateProvince
        }).ToListAsync();
        return new Response<List<GetLocationsDto>>(list);
    }

    public async Task<Response<AddLocationsDto>> AddLocation(AddLocationsDto location)
    {
        var newLocation = new Locations()
        {
            LocationId = location.LocationId,
            StreetAddress = location.StreetAddress,
            PostalCode = location.PostalCode,
            City = location.City,
            StateProvince = location.StateProvince,
            CountryId = location.CountryId
        };
        _context.Locations.Add(newLocation);
        await _context.SaveChangesAsync();
        return new Response<AddLocationsDto>(location);
    }

    public async Task<Response<AddLocationsDto>> UpdateLocation(AddLocationsDto location)
    {
        var find = await _context.Locations.FindAsync(location.LocationId);
        find.StreetAddress = location.StreetAddress;
        find.PostalCode = location.PostalCode;
        find.City = location.City;
        find.StateProvince = location.StateProvince;
        await _context.SaveChangesAsync();
        return new Response<AddLocationsDto>(location);
    }

    public async Task<Response<string>> DeleteLocation(int id)
    {
        var find = await _context.Locations.FindAsync(id);
        _context.Locations.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Location has been Deleted");
    }
}
