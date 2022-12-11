using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class DepartmentService
{
    private readonly DataContext _context;
    public DepartmentService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetDepartmentsDto>>> GetDepartments()
    {
        var list = await _context.Departments.Select(t => new GetDepartmentsDto()
        {
            DepartmentId = t.DepartmentId,
            DepartmentName = t.DepartmentName,
            ManagerId = t.ManagerId,
            LocationId = t.LocationId  
        }).ToListAsync();
        return new Response<List<GetDepartmentsDto>>(list);
    }

    public async Task<Response<AddDepartmentsDto>> AddDepartment(AddDepartmentsDto department)
    {
        var newDepartments = new Departments()
        {
            DepartmentName = department.DepartmentName,
            ManagerId = department.ManagerId,
            LocationId = department.LocationId
        };
        _context.Departments.Add(newDepartments);
        await _context.SaveChangesAsync();
        return new Response<AddDepartmentsDto>(department);
    }

    public async Task<Response<AddDepartmentsDto>> UpdateDepartments(AddDepartmentsDto department)
    {
        var find = await _context.Departments.FindAsync(department.DepartmentId);
        find.DepartmentName = department.DepartmentName;
        find.ManagerId = department.ManagerId;
        find.LocationId = department.LocationId;
        await _context.SaveChangesAsync();
        return new Response<AddDepartmentsDto>(department);
    }

    public async Task<Response<string>> DeleteDepartments(int id)
    {
        var find = await _context.Departments.FindAsync(id);
        _context.Departments.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Department has been Deleted");
    }
}
