using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class RegionService
{
    private readonly DataContext _context;

    public RegionService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetRegionsDto>>> GetRegions()
    {
        var list = await _context.Regions.Select(t => new GetRegionsDto()
        {
            RegionId = t.RegionId,
            RegionName = t.RegionName
        }).ToListAsync();
        return new Response<List<GetRegionsDto>>(list);
    }

    public async Task<Response<AddRegionsDto>> AddRegion(AddRegionsDto region)
    {
        var newRegions = new Regions()
        {
            RegionId = region.RegionId,
            RegionName = region.RegionName
        };
        _context.Regions.Add(newRegions);
        await _context.SaveChangesAsync();
        return new Response<AddRegionsDto>(region); 
    }

    public async Task<Response<AddRegionsDto>> UpdateRegions(AddRegionsDto region)
    {
        var find = await _context.Regions.FindAsync(region.RegionId);
        find.RegionName = region.RegionName;
        await _context.SaveChangesAsync();
        return new Response<AddRegionsDto>(region);
    }

    public async Task<Response<string>> DeleteRegion(int id)
    {
        var find = await _context.Regions.FindAsync(id);
        _context.Regions.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Region has been Deleted");
    }
}
