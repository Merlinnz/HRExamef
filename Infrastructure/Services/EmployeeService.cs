using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EmployeeService
{
    private readonly DataContext _context;
    public EmployeeService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<Response<List<GetEmployeesDto>>> GetEmployees()
    {
        var list = await _context.Employees.Select(t => new GetEmployeesDto()
        {
            EmployeeId = t.EmployeeId,
            FirstName = t.FirstName,
            LastName = t.LastName,
            Email = t.Email,
            PhoneNumber = t.PhoneNumber,
            HireDate = t.HireDate,
            JobId = t.JobId,
            Salary = t.Salary,
            CommissionPct = t.CommissionPct,
            ManagerId = t.ManagerId,
            DepartmentId = t.DepartmentId
        }).ToListAsync();
        return new Response<List<GetEmployeesDto>>(list);
    }

    public async Task<Response<AddEmployeesDto>> AddEmployee(AddEmployeesDto employee)
    {
        var newEmployees = new Employees()
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber,
            HireDate = employee.HireDate,
            JobId = employee.JobId,
            Salary = employee.Salary,
            CommissionPct = employee.CommissionPct,
            ManagerId = employee.ManagerId,
            DepartmentId = employee.DepartmentId
        };
        _context.Employees.Add(newEmployees);
        await _context.SaveChangesAsync();
        return new Response<AddEmployeesDto>(employee);
    }

    public async Task<Response<AddEmployeesDto>> UpdateEmployee(AddEmployeesDto employee)
    {
        var find = await _context.Employees.FindAsync(employee.EmployeeId);
        find.FirstName = employee.FirstName;
        find.LastName = employee.LastName;
        find.Email = employee.Email;
        find.PhoneNumber = employee.PhoneNumber;
        find.HireDate = employee.HireDate;
        find.JobId = employee.JobId;
        find.Salary = employee.Salary;
        find.CommissionPct = employee.CommissionPct;
        find.ManagerId = employee.ManagerId;
        find.DepartmentId = employee.DepartmentId;
        await _context.SaveChangesAsync();
        return new Response<AddEmployeesDto>(employee); 
    }

    public async Task<Response<string>> DeleteEmployee(int id)
    {
        var find = await _context.Employees.FindAsync(id);
        _context.Employees.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Employee has been Deleted");
    }
}
