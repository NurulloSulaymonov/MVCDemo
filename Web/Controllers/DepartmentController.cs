using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class DepartmentController:Controller
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }
    
    //Get
    public async Task<IActionResult> Index()
    { 
        var departments = await _departmentService.GetDepartments();
        return View(departments);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        var emptyDepartment = new AddDepartmentDto();
        return View(emptyDepartment);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(AddDepartmentDto addDepartmentDto)
    {
        if (ModelState.IsValid == false)
        {
            return View(addDepartmentDto);
        }
        await _departmentService.AddDepartment(addDepartmentDto);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var department = await _departmentService.GetDepartmentById(id);
        return View(department);
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(UpdateDepartmentDto updateDepartmentDto)
    {
        if (ModelState.IsValid == false)
        {
            return View(updateDepartmentDto);
        }
        await _departmentService.UpdateDepartment(updateDepartmentDto);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        await _departmentService.DeleteDepartment(id);
        return RedirectToAction("Index");
    }
    
    
   
}