using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class JobGradeService
{
    private readonly DataContext _context;
    public JobGradeService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<AddJobGradesDto>>> GetJobGrades()
    {
        var list = await _context.JobGrades.Select(g => new AddJobGradesDto()
        {
            Id = g.Id,
            GradeLevel = g.GradeLevel,
            LowestSalary = g.LowestSalary,
            HighestSalary = g.HighestSalary
        }).ToListAsync();
        return new Response<List<AddJobGradesDto>>(list);
    }

    public async Task<Response<AddJobGradesDto>> AddJobGrades(AddJobGradesDto jobgrades)
    {
        var newJobGrades = new JobGrades()
        {
            GradeLevel = jobgrades.GradeLevel,
            LowestSalary = jobgrades.LowestSalary,
            HighestSalary = jobgrades.HighestSalary
        };
        _context.JobGrades.Add(newJobGrades);
        await _context.SaveChangesAsync();
        return new Response<AddJobGradesDto>(jobgrades);
    }

    public async Task<Response<AddJobGradesDto>> UpdateJobGrades(AddJobGradesDto jobgrades)
    {
        var find = await _context.JobGrades.FindAsync(jobgrades.Id);
        find.GradeLevel = jobgrades.GradeLevel;
        find.LowestSalary = jobgrades.LowestSalary;
        find.HighestSalary = jobgrades.HighestSalary;
        await _context.SaveChangesAsync();
        return new Response<AddJobGradesDto>(jobgrades); 
    }

    public async Task<Response<string>> DeleteJobGrade(int id)
    {
        var find = await _context.JobGrades.FindAsync(id);
        _context.JobGrades.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("JobGrade Has Been Deleted");
    }
}
