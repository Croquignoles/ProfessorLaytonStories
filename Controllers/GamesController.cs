
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore;
using ProfessorLayton.Data;
using ProfessorLayton.Models;

namespace ProfessorLayton.Controllers;


public class GamesController : Controller
{
    private readonly ProfessorLaytonContext _context=null!;
    //private readonly ILogger<GamesController> _logger=null!;

    public GamesController(ProfessorLaytonContext context)
    {
        _context = context;
    }

    // GET: Games
    public async Task<IActionResult> Index()
    {
        var jeux = await _context.Games
            .ToListAsync();

        return View(jeux);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        // Lookup student and associated enrollments
        var game = await _context.Games
            .FirstOrDefaultAsync(m => m.Id == id);
        if (game == null)
        {
            return NotFound();
        }

        return View(game);
    }
}