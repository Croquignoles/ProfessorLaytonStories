using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore;
using ProfessorLayton.Data;
using ProfessorLayton.Models;

namespace ProfessorLayton.Controllers;


public class MusicsController : Controller
{
    private readonly ProfessorLaytonContext _context=null!;
    //private readonly ILogger<GamesController> _logger=null!;

    public MusicsController(ProfessorLaytonContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var musics = await _context.Musics
            .Include(g=>g.Games)
            .ToListAsync();

        return View(musics);
    }

    //POST: Music/Create
    public async Task<IActionResult> Create()
    {
        var musics = await _context.Musics
            .ToListAsync();

        return View();
    }

    //Méthode d'action pour l'ajout d'une musique
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,URL")] Music music)
    {
        // Apply model validation rules
        if (ModelState.IsValid)
        {
            _context.Add(music);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // At this point, something failed: redisplay form
        return View(music);
    }

    //PUT: Musics/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var music = await _context.Musics.FindAsync(id);
        if (music == null)
        {
            return NotFound();
        }
        return View(music);
    }

    //Méthode d'action pour la modification d'une musique
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,URL")] Music music)
    {
        if (id != music.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(music);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicExists(music.Id))
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
        return View(music);
    }

    private bool MusicExists(int id)
    {
        return _context.Musics.Any(e => e.Id == id);
    }

     // GET: Music/Delete/id
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var music = await _context.Musics
            .FirstOrDefaultAsync(m => m.Id == id);
        if (music == null)
        {
            return NotFound();
        }

        return View(music);
    }

    //Méthode d'action associée à la suppression d'une musique 
    // POST: Movies/Delete/id
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var music = await _context.Musics.FindAsync(id);
        _context.Musics.Remove(music!);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}