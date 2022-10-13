using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Web.Controllers;

public class EmployeeController:Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly IDepartmentService _departmentService;

    public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
    {
        _employeeService = employeeService;
        _departmentService = departmentService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var employees = await _employeeService.GetEmployees();
        return View(employees);
    }
    
    [HttpGet]
    public async Task<IActionResult> Add()
    { 
        ViewBag.Departments = await _departmentService.GetDepartments();
        var employee = new AddEmployeeDto();
        return View(employee);
    }
    [HttpPost]
    public async Task<IActionResult> Add(AddEmployeeDto employee)
    {
        if (ModelState.IsValid == false)
        {
            ViewBag.Departments = _departmentService.GetDepartments();
            return View(employee);
        }
        await _employeeService.CreateEmployee(employee);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        ViewBag.Departments = await _departmentService.GetDepartments();
        var employee = await _employeeService.GetEmployeeById(id);
        return View(employee);
        
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateEmployeeDto employee)
    {
        await _employeeService.UpdateEmployee(employee);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        await _employeeService.DeleteEmployee(id);
        return RedirectToAction("Index");
    }
    
   

}
