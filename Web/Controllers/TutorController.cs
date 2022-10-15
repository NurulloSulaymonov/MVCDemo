using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace Web.Controllers;

public class TutorController : Controller
{
    private readonly ITutorService _tutorService;

    public TutorController(ITutorService tutorService)
    {
        _tutorService = tutorService;
    }

    //Get
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var getTutors = await _tutorService.GetTutors();
        return View(getTutors);
    }

    //Add
    [HttpGet]
    public IActionResult Create()
    {
        var emptyTutor = new AddTutorDto();
        return View(emptyTutor);
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddTutorDto addTutorDto)
    {
        if (ModelState.IsValid == false)
        {
            return View(addTutorDto);
        }
        await _tutorService.CreateTutor(addTutorDto);
        return RedirectToAction("Index");
    }
    
    //Update
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var getTutorDto = await _tutorService.GetTutorById(id);
        return View(getTutorDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UpdateTutorDto updateTutorDto)
    {
        if (ModelState.IsValid == false)
        {
            return View(updateTutorDto);
        }
        await _tutorService.EditTutor(updateTutorDto);
        return RedirectToAction("Index");
    }

    //Delete
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        await _tutorService.DeleteTutor(id);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var employee = await _tutorService.GetTutorById(id);
        return View(employee);
    }
}
