using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EmployeeService:IEmployeeService
{
    private readonly DataContext _context;

    public EmployeeService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<List<EmployeeDto>> GetEmployees()
    {
        var employees = await _context.Employees
            .Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email,
                Phone = e.Phone,
                Department = e.Department.Name
            })
            .ToListAsync();
        
        return employees;
    }
    
    public async Task<EmployeeDto> GetEmployee(int id)
    {
        var employee = await _context.Employees
            .Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email,
                Phone = e.Phone,
                Department = e.Department.Name
            })
            .FirstOrDefaultAsync(e => e.Id == id);
        
        return employee;
    }
    
    public async Task<EmployeeDto> CreateEmployee(AddEmployeeDto employeeDto)
    {
        var employee = new Employee
        {
            Name = employeeDto.Name,
            Email = employeeDto.Email,
            Phone = employeeDto.Phone,
            DepartmentId = employeeDto.DepartmentId
        };
        
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        
        employeeDto.Id = employee.Id;
        
        var employeeCreated = await GetEmployee(employee.Id);
        return employeeCreated;
    }
    
    public async Task<EmployeeDto> UpdateEmployee(UpdateEmployeeDto employeeDto)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeDto.Id);
        
        if (employee == null)
        {
            return null;
        }
        
        employee.Name = employeeDto.Name;
        employee.Email = employeeDto.Email;
        employee.Phone = employeeDto.Phone;
        employee.DepartmentId = employeeDto.DepartmentId;
        
        await _context.SaveChangesAsync();
        
        var employeeUpdated = await GetEmployee(employee.Id);
        return employeeUpdated;
    }
    
    public async Task<bool> DeleteEmployee(int id)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        
        if (employee == null)
        {
            return false;
        }
        
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        
        return true;
    }
}