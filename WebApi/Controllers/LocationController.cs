using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class LocationController
{
    private readonly LocationService _locationService;
    public LocationController(LocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet("GetLocations")]
    public async Task<Response<List<GetLocationsDto>>> GetLocations()
    {
        return await _locationService.GetLocations();
    }

    [HttpPost("InsertNewLocations")]
    public async Task<Response<AddLocationsDto>> AddLocation(AddLocationsDto location)
    {
        return await _locationService.AddLocation(location);
    }

    [HttpPut("UpdateLocations")]
    public async Task<Response<AddLocationsDto>> UpdateLocation(AddLocationsDto location)
    {
        return await _locationService.UpdateLocation(location);
    }

    [HttpDelete("DeleteLocations")]
    public async Task<Response<string>> DeleteLocation(int id)
    {
        return await _locationService.DeleteLocation(id);
    }
}
