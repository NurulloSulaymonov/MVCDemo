using Domain.Dtos;

namespace Infrastructure.Services;

public interface IEmployeeService
{
    Task<List<EmployeeDto>> GetEmployees();
    Task<UpdateEmployeeDto> GetEmployeeById(int id);
    Task<AddEmployeeDto> CreateEmployee(AddEmployeeDto employeeDto);
    Task<UpdateEmployeeDto> UpdateEmployee(UpdateEmployeeDto employeeDto);
    Task<bool> DeleteEmployee(int id);
}