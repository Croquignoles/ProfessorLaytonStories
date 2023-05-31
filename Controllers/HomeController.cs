using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProfessorLayton.Models;

namespace ProfessorLayton.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Games()
    {
        return View();
    }
    public IActionResult Characters()
    {
        return View();
    }
    public IActionResult Musics()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
