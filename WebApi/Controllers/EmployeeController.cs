using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class EmployeeController
{
    private readonly EmployeeService _employeeService;
    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("GetEmployees")]
    public async Task<Response<List<GetEmployeesDto>>> GetEmployees()
    {
        return await _employeeService.GetEmployees();
    }

    [HttpPost("InsertNewEmployee")]
    public async Task<Response<AddEmployeesDto>> AddEmployees(AddEmployeesDto employee)
    {
        return await _employeeService.AddEmployee(employee);
    }

    [HttpPut("UpdateEmployees")]
    public async Task<Response<AddEmployeesDto>> UpdateEmployees(AddEmployeesDto employees)
    {
        return await _employeeService.UpdateEmployee(employees);
    }

    [HttpDelete("DeleteEmployees")]
    public async Task<Response<string>> DeleteEmployees(int id)
    {
        return await _employeeService.DeleteEmployee(id);
    }
}
