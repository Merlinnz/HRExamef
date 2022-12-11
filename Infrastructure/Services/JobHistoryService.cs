using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class JobHistoryService
{
    private readonly DataContext _context;
    public JobHistoryService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetJobHistoryDto>>> GetJobHistories()
    {
        var list = await _context.JobHistories.Select(t => new GetJobHistoryDto()
        {
            Id = t.Id,
            EmployeeId = t.EmployeeId,
            StartDate = t.StartDate,
            EndDate = t.EndDate,
            JobId = t.JobId,
            DepartmentId = t.DepartmentId
        }).ToListAsync();
        return new Response<List<GetJobHistoryDto>>(list);
    }

    public async Task<Response<AddJobHistoryDto>> AddJobHistory(AddJobHistoryDto jobhistory)
    {
        var newJobHistory = new JobHistory()
        {
            EmployeeId = jobhistory.EmployeeId,
            StartDate = jobhistory.StartDate,
            EndDate = jobhistory.EndDate,
            JobId = jobhistory.JobId,
            DepartmentId = jobhistory.DepartmentId
        };
        _context.JobHistories.Add(newJobHistory);
        await _context.SaveChangesAsync();
        return new Response<AddJobHistoryDto>(jobhistory);
    }

    public async Task<Response<AddJobHistoryDto>> UpdateJobHistory(AddJobHistoryDto jobhistory)
    {
        var find = await _context.JobHistories.FindAsync(jobhistory.Id);
        find.EmployeeId = jobhistory.EmployeeId;
        find.StartDate = jobhistory.StartDate;
        find.EndDate = jobhistory.EndDate;
        find.JobId = jobhistory.JobId;
        find.DepartmentId = jobhistory.DepartmentId;
        await _context.SaveChangesAsync();
        return new Response<AddJobHistoryDto>(jobhistory);
    }

    public async Task<Response<string>> DeleteJobHistory(int id)
    {
        var find = await _context.JobHistories.FindAsync(id);
        _context.JobHistories.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("JobHistory has been Deleted");
    }
}
