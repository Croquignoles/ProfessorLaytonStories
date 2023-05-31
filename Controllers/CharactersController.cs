
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using ProfessorLayton.Data;
using ProfessorLayton.Models;

namespace ProfessorLayton.Controllers;

public class CharactersController : Controller
{
    //private readonly ILogger<CharactersController> _logger;
    private readonly ProfessorLaytonContext _context=null!;
    private readonly IWebHostEnvironment _hostEnivronment=null!;
    public CharactersController(ProfessorLaytonContext context,IWebHostEnvironment hostEnivronment)
    {
        _context = context;
        this._hostEnivronment=hostEnivronment;
    }

    //GET : Characters 
    public async Task<IActionResult> Index()
    {
        var persos = await _context.Characters
            .ToListAsync();
        return View(persos);
    }
    //POST: Character/Create
    public async Task<IActionResult> Create()
    {
        var characters = await _context.Characters
            .ToListAsync();

        return View();
    }

    //Méthode d'action pour l'ajout d'un personnage
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FirstName,LastName,IsBadGuy,Description,ImageFile1")] Character character)
    {
        // Apply model validation rules
        if (ModelState.IsValid)
        {
            if(character.ImageFile1!=null)
            {
            //Save image to wwwroot/img/character
            string wwwrootPath=_hostEnivronment.WebRootPath;
            string fileName=Path.GetFileNameWithoutExtension(character.ImageFile1.FileName);
            string extension=Path.GetExtension(character.ImageFile1.FileName);
            string path=Path.Combine(wwwrootPath+"/img/character",fileName+extension);
            using (var fileStream=new FileStream (path,FileMode.Create))
            {
                
                    await character.ImageFile1.CopyToAsync(fileStream);
            }
            }
            _context.Add(character);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // At this point, something failed: redisplay form
         var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));
         return Json(new {allErrors});
    }


    
     // GET: Character/Delete/id
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var character = await _context.Characters
            .FirstOrDefaultAsync(c => c.Id == id);
        if (character == null)
        {
            return NotFound();
        }

        return View(character);
    }

    //Méthode d'action associée à la suppression d'un personnage
    // POST: Characters/Delete/id
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var character = await _context.Characters.FindAsync(id);
        _context.Characters.Remove(character!);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
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

        // Lookup characters details
        var character = await _context.Characters
            .Include(g=>g.Games)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (character == null)
        {
            return NotFound();
        }

        return View(character);
    }
}