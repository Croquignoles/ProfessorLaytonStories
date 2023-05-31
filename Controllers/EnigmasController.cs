
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ProfessorLayton.Data;
using ProfessorLayton.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ProfessorLayton.Controllers;


public class EnigmasController : Controller
{
    private readonly ProfessorLaytonContext _context=null!;
    private readonly IWebHostEnvironment _hostEnivronment=null!;
    //private readonly ILogger<GamesController> _logger=null!;

    public EnigmasController(ProfessorLaytonContext context,IWebHostEnvironment hostEnivronment)
    {
        _context = context;
        this._hostEnivronment=hostEnivronment;
    }

    // GET: Games
    public async Task<IActionResult> Index()
    {
        var enigmes = await _context.Enigmas
            .Include(g=>g.Game)
            .ToListAsync();
        return View(enigmes);

    }

    public async Task<IActionResult> Content(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        // Lookup enigmas
        var enigme = await _context.Enigmas
            .Include(h=>h.Hints)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (enigme == null)
        {
            return NotFound();
        }
        return View(enigme);
    }

    //POST: enigma/Create
    public async Task<IActionResult> Create()
    {
        var enigma = await _context.Enigmas
            .Include(g=>g.Game)
            .Include(s=>s.Solution)
            .ToListAsync();
        var availableGamesQuery=from g in _context.Games select g;
        var availableGames=availableGamesQuery.ToList();
        ViewData["Enigma"]=enigma;  
        ViewData["GameId"]=new SelectList(availableGames,"Id","Title")  ;                      
        return View();
    }
    

    //Méthode d'action pour l'ajout d'une enigme
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Content,GameId")] EnigmaDTO enigmaDTO)
    {
        // Apply model validation rules
        if (ModelState.IsValid)
        {
            Enigma enigma=new Enigma(enigmaDTO);
            var game = _context.Games.Find(enigma.GameId);
            if(enigma.ImageFile!=null)
            {
            //Save image to wwwroot/img/character
            string wwwrootPath=_hostEnivronment.WebRootPath;
            string fileName=Path.GetFileNameWithoutExtension(enigma.ImageFile.FileName);
            string extension=Path.GetExtension(enigma.ImageFile.FileName);
            string path=Path.Combine(wwwrootPath+"/img/enigma",fileName+extension);
            using (var fileStream=new FileStream (path,FileMode.Create))
            {
                
                    await enigma.ImageFile.CopyToAsync(fileStream);
            }
            }
            

            // Define game for new enigma
            enigma.Game = game!;

            _context.Add(enigma);
            await _context.SaveChangesAsync();
            return Redirect("~/Solution/Create");
            //return RedirectToAction(nameof(Index));
        }
        else
        {
        // At this point, something failed: redisplay form
         var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));
         return Json(new {allErrors});
        //return View(enigma);
        }
        
    }

    //PUT: Enigmas/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var enigma = await _context.Enigmas.FindAsync(id);
        if (enigma == null)
        {
            return NotFound();
        }
        return View(enigma);
    }

    //Méthode d'action pour la modification d'une enigme
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Content,GameId")] EnigmaDTO enigmaDTO)
    {
        
        if (id != enigmaDTO.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            Enigma enigma=new Enigma(enigmaDTO);
            var game = _context.Games.Find(enigma.GameId);

            // Define game for new enigma
            enigma.Game = game!;
            try
            {
                _context.Update(enigma);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnigmaExists(enigma.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
         var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));
         return Json(new {allErrors});
        //return View(enigma);
    }

    private bool EnigmaExists(int id)
    {
        return _context.Enigmas.Any(e => e.Id == id);
    }

     // GET: Enigma/Delete/id
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var enigma = await _context.Enigmas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (enigma == null)
        {
            return NotFound();
        }

        return View(enigma);
    }

    //Méthode d'action associée à la suppression d'une enigme 
    // POST: Movies/Delete/id
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var enigma = await _context.Enigmas.FindAsync(id);
        var sol=await _context.Solutions.FirstOrDefaultAsync(s => s.EnigmaId == id);
        _context.Enigmas.Remove(enigma!);
        if(sol!=null)
            _context.Solutions.Remove(sol);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Solution(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        // Lookup student and associated enrollments
        var solution = await _context.Solutions
            .FirstOrDefaultAsync(m => m.EnigmaId == id);
        if (solution == null)
        {
            return NotFound();
        }

        return View(solution);
    }

    
        

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}