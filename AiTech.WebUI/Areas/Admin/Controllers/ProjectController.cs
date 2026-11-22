using AiTech.WebUI.DTOs.ProjectDtos;
using AiTech.WebUI.Services.CategoryServices;
using AiTech.WebUI.Services.ProjectServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AiTech.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class ProjectController(IProjectService projectService, ICategoryService categoryService) : Controller
{
    private async Task getCategoriesAsync()
    {
        var categories = await categoryService.GetAllAsync();
        ViewBag.Categories = (from category in categories
                select new SelectListItem
                {
                    Text = category.Title,
                    Value = category.Id.ToString(),
                }).ToList();
    }
    
    public async Task<IActionResult> Index()
    {
        var projects = await projectService.GetProjectsWithCategory();
        return View(projects);
    }

    public async Task<IActionResult> Create()
    {
        await getCategoriesAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProjectDto dto)
    {
        if (!ModelState.IsValid)
        {
            await getCategoriesAsync();
            return View(dto);
        }
        
        var result = await projectService.CreateAsync(dto);

        if (!result.IsSuccess)
        {
            result.AddToModelState(ModelState);
            await getCategoriesAsync();
            return View(dto);
        }
        
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Update(int id)
    {
        await getCategoriesAsync();
        var project = await projectService.GetByIdForUpdateAsync(id);
        return View(project);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateProjectDto dto)
    {
        if (!ModelState.IsValid)
        {
            await getCategoriesAsync();
            return View(dto);
        }

        var result = await projectService.UpdateAsync(dto);

        if (!result.IsSuccess)
        {
            result.AddToModelState(ModelState);
            await getCategoriesAsync();
            return View(dto);
        }
        
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await projectService.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}