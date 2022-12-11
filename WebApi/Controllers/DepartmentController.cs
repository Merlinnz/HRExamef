using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class DepartmentController
{
    private readonly DepartmentService _departmentService;
    public DepartmentController(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet("GetDepartments")]
    public async Task<Response<List<GetDepartmentsDto>>> GetDepartments()
    {
        return await _departmentService.GetDepartments();
    }

    [HttpPost("InsertNewDepartment")]
    public async Task<Response<AddDepartmentsDto>> AddDepartments(AddDepartmentsDto department)
    {
        return await _departmentService.AddDepartment(department);
    }

    [HttpPut("UpdateDepartment")]
    public async Task<Response<AddDepartmentsDto>> UpdateDepartment(AddDepartmentsDto department)
    {
        return await _departmentService.UpdateDepartments(department);
    }

    [HttpDelete("DeleteDepartment")]
    public async Task<Response<string>> DeleteDepartment(int id)
    {
        return await _departmentService.DeleteDepartments(id);
    }
}
