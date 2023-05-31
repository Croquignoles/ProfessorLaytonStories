using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfessorLayton.Data;
using ProfessorLayton.Models;


namespace ProfessorLayton.Controllers;


public class SolutionController : Controller
{
    private readonly ProfessorLaytonContext _context=null!;
    //private readonly ILogger<GamesController> _logger=null!;

    public SolutionController(ProfessorLaytonContext context)
    {
        _context = context;
    }

   public async Task<IActionResult> Content(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        // Lookup enigmas
        var solution = await _context.Solutions
            .Include(h=>h.Enigma)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (solution == null)
        {
            return NotFound();
        }
        return View(solution);
    }
    
    public async Task<IActionResult> Create()
    {
        var solution = await _context.Solutions
            .Include(e=>e.Enigma)
            .ThenInclude(g=>g.Game)
            .ToListAsync();
        var latestEnigmaId=(from e in _context.Enigmas select e.Id).Max();
        ViewData["Solution"]=solution;  
        ViewData["EnigmaId"]=latestEnigmaId  ;                      
        return View();
    }

    //Méthode d'action pour l'ajout d'une enigme
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Content,urlImg")] SolutionDTO solutionDTO)
    {
        // Apply model validation rules
        if (ModelState.IsValid)
        {
            Solution solution=new Solution(solutionDTO);
            var latestEnigmaId=(from e in _context.Enigmas select e.Id).Max();
            solution.EnigmaId=latestEnigmaId;
            var enigma = _context.Enigmas.Find(solution.EnigmaId);

            // Define enigma for new solution
            solution.Enigma = enigma!;

            _context.Add(solution);
            await _context.SaveChangesAsync();
            return Redirect("~/Hints/Create");
        }
        else
        {
        // At this point, something failed: redisplay form
         var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));
         return Json(new {allErrors});
        //return View(enigma);
        }
        
    }
}