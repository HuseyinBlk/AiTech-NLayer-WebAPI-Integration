using AiTech.WebUI.DTOs.BannerDtos;
using AiTech.WebUI.Services.BannerServices;
using Microsoft.AspNetCore.Mvc;

namespace AiTech.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class BannerController(IBannerService bannerService) : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        var values = await bannerService.GetAllAsync();
        return View(values);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBannerDto dto)
    {
        if (!ModelState.IsValid) return View(dto);
        
        var result = await bannerService.CreateAsync(dto);

        if (!result.IsSuccess)
        {
            result.AddToModelState(ModelState);
            return View(dto);
        }
        
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var value = await bannerService.GetByIdForUpdateAsync(id);
        return View(value);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UpdateBannerDto dto)
    {
        if (!ModelState.IsValid) return View(dto);

        var result = await bannerService.UpdateAsync(dto);

        if (!result.IsSuccess)
        {
            result.AddToModelState(ModelState);
            return View(dto);
        }
        
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await  bannerService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> MakeActive(int id)
    {
        await  bannerService.MakeActiveAsync(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> MakeInactive(int id)
    {
        await  bannerService.MakeInactiveAsync(id);
        return RedirectToAction(nameof(Index));
    }
}