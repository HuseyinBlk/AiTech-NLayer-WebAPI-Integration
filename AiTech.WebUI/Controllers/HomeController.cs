using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AiTech.WebUI.Models;
using AiTech.WebUI.Services.GeminiServices;

namespace AiTech.WebUI.Controllers;

public class HomeController(IGeminiService geminiService) : Controller
{
    private readonly ILogger<HomeController> _logger;

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string prompt)
    {
        var response = await geminiService.GetGeminiDataAsync(prompt);
        if (response != null)
        {
            ViewBag.Response = response;
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}