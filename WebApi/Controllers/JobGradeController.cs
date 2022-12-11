using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class JobGradeController
{
    private readonly JobGradeService _jobGradeService;
    public JobGradeController(JobGradeService jobGradeService)
    {
        _jobGradeService = jobGradeService;
    }

    [HttpGet("GetJobGrades")]
    public async Task<Response<List<AddJobGradesDto>>> GetJobGrades()
    {
        return await _jobGradeService.GetJobGrades();
    }

    [HttpPost("InsertNewJobGrades")]
    public async Task<Response<AddJobGradesDto>> AddJobGrades(AddJobGradesDto jobgrades)
    {
        return await _jobGradeService.AddJobGrades(jobgrades);
    }

    [HttpPut("UpdateJobGrades")]
    public async Task<Response<AddJobGradesDto>> UpdateJobGrades(AddJobGradesDto jobgrades)
    {
        return await _jobGradeService.UpdateJobGrades(jobgrades);
    }

    [HttpDelete("DeleteJobGrades")]
    public async Task<Response<string>> DeleteJobGrades(int id)
    {
        return await _jobGradeService.DeleteJobGrade(id);
    }
}
