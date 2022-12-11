using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class RegionController
{
    private readonly RegionService _regionService;
    public RegionController(RegionService regionService)
    {
        _regionService = regionService;
    }

    [HttpGet("GetRegions")]
    public async Task<Response<List<GetRegionsDto>>> GetRegions()
    {
        return await _regionService.GetRegions();
    }

    [HttpPost("InsertNewRegions")]
    public async Task<Response<AddRegionsDto>> AddRegion(AddRegionsDto region)
    {
        return await _regionService.AddRegion(region);
    }

    [HttpPut("UpdateRegions")]
    public async Task<Response<AddRegionsDto>> UpdateRegions(AddRegionsDto region)
    {
        return await _regionService.UpdateRegions(region);
    }

    [HttpDelete("DeleteRegions")]
    public async Task<Response<string>> DeleteRegion(int id)
    {
        return await _regionService.DeleteRegion(id);
    }
}
