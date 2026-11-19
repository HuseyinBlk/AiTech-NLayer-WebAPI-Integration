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
}