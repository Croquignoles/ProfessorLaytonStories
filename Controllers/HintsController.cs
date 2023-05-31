using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfessorLayton.Data;
using ProfessorLayton.Models;


namespace ProfessorLayton.Controllers;


public class HintsController : Controller
{
    private readonly ProfessorLaytonContext _context=null!;
    //private readonly ILogger<GamesController> _logger=null!;

    public HintsController(ProfessorLaytonContext context)
    {
        _context = context;
    }

    
    public async Task<IActionResult> Create()
    {
        var hints = await _context.Hints
            .Include(e=>e.Enigma)
            .ThenInclude(g=>g.Game)
            .ToListAsync();
        var latestEnigmaId=(from e in _context.Enigmas select e.Id).Max();
        ViewData["Hints"]=hints;  
        ViewData["EnigmaId"]=latestEnigmaId  ;                      
        return View();
    }

    //Méthode d'action pour l'ajout des indices 
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Content,HintRange")]HintDTO hintDTO) 
    {

        // Apply model validation rules
        if (ModelState.IsValid)
        {
            Hint hint=new Hint(hintDTO);
            var latestEnigmaId=(from e in _context.Enigmas select e.Id).Max();
            hint.EnigmaId=latestEnigmaId;
            var enigma = _context.Enigmas.Find(hint.EnigmaId);
            
            //Count the number of hints available for the enigma you're trying to create
            var nbHint=(from h in _context.Hints where h.EnigmaId==latestEnigmaId select h).Count();
            // Define enigma for new solution
            hint.Enigma = enigma!;

            _context.Add(hint);
            await _context.SaveChangesAsync();
            if(enigma!=null)
                while(nbHint<2)
                {
                    enigma.Hints.Add(hint);
                    ViewData["Enigma"]=enigma;
                    return Redirect("~/Hints/Create");
                }                   
            return Redirect("~/Enigmas/Index");
            
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