using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class JobHistoryController
{
    private readonly JobHistoryService _jobHistoryService;
    public JobHistoryController(JobHistoryService jobHistoryService)
    {
        _jobHistoryService = jobHistoryService;
    }

    [HttpGet("GetJobHistories")]
    public async Task<Response<List<GetJobHistoryDto>>> GetJobHistories()
    {
        return await _jobHistoryService.GetJobHistories();
    }

    [HttpPost("InsertNewJobHistory")]
    public async Task<Response<AddJobHistoryDto>> AddJobHistory(AddJobHistoryDto jobhistory)
    {
        return await _jobHistoryService.AddJobHistory(jobhistory);
    }

    [HttpPut("UpdateJobHistory")]
    public async Task<Response<AddJobHistoryDto>> UpdateJobHistory(AddJobHistoryDto jobhistory)
    {
        return await _jobHistoryService.UpdateJobHistory(jobhistory);
    }

    [HttpDelete("DeleteJobHistory")]
    public async Task<Response<string>> DeleteJobHistory(int id)
    {
        return await _jobHistoryService.DeleteJobHistory(id);
    }  
}
