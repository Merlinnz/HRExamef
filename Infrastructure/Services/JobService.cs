using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class JobService
{
    private readonly DataContext _context;
    public JobService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetJobsDto>>> GetJobs()
    {
        var list = await _context.Jobs.Select(t => new GetJobsDto()
        {
            JobId = t.JobId,
            JobTitle = t.JobTitle,
            MinSalary = t.MinSalary,
            MaxSalary = t.MaxSalary
        }).ToListAsync();
        return new Response<List<GetJobsDto>>(list);
    }

    public async Task<Response<AddJobsDto>> AddJobs(AddJobsDto job)
    {
        var newJobs = new Jobs()
        {
            JobTitle = job.JobTitle,
            MinSalary = job.MinSalary,
            MaxSalary = job.MaxSalary
        };
        _context.Jobs.Add(newJobs);
        await _context.SaveChangesAsync();
        return new Response<AddJobsDto>(job);
    }

    public async Task<Response<AddJobsDto>> UpdateJobs(AddJobsDto job)
    {
        var find = await _context.Jobs.FindAsync(job.JobId);
        find.JobTitle = job.JobTitle;
        find.MinSalary = job.MinSalary;
        find.MaxSalary = job.MaxSalary;
        await _context.SaveChangesAsync();
        return new Response<AddJobsDto>(job);
    }

    public async Task<Response<string>> DeleteJob(int id)
    {
        var find = await _context.Jobs.FindAsync(id);
        _context.Jobs.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Job deleted successfully");
    }
}
