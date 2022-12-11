using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class JobController
{
    private readonly JobService _jobService;
    public JobController(JobService jobService)
    {
        _jobService = jobService;
    }

    [HttpGet("GetJobs")]
    public async Task<Response<List<GetJobsDto>>> GetJobs()
    {
        return await _jobService.GetJobs();
    }

    [HttpPost("InsertNewJob")]
    public async Task<Response<AddJobsDto>> AddJobs(AddJobsDto job)
    {
        return await _jobService.AddJobs(job);
    }

    [HttpPut("UpdateJob")]
    public async Task<Response<AddJobsDto>> UpdateJob(AddJobsDto job)
    {
        return await _jobService.UpdateJobs(job);
    }

    [HttpDelete("DeleteJob")]
    public async Task<Response<string>> DeleteJobs(int id)
    {
        return await _jobService.DeleteJob(id);
    }
}
