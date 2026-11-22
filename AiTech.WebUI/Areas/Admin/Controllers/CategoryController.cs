using AiTech.WebUI.DTOs.CategoryDtos;
using AiTech.WebUI.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace AiTech.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController(ICategoryService categoryService) : Controller
{
    
    public async Task<IActionResult> Index()
    {
        var categories = await categoryService.GetAllAsync();
        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto dto)
    {
        if(!ModelState.IsValid) return View(dto);
        
        var result = await categoryService.CreateAsync(dto);
        if (!result.IsSuccess)
        {
            result.AddToModelState(ModelState);
            return View(dto);
        }
        
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Update(int id)
    {
        var category = await categoryService.GetByIdAsync(id);
        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateCategoryDto dto)
    {
        if(!ModelState.IsValid) return View(dto);

        var result = await categoryService.UpdateAsync(dto);
        if (!result.IsSuccess)
        {
            result.AddToModelState(ModelState);
            return View(dto);
        }
        
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await categoryService.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}
