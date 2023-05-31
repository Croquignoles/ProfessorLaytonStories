using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfessorLayton.Data;
using ProfessorLayton.Models;
 
namespace ProfessorLayton.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnigmasApiController : ControllerBase
{
    private readonly ProfessorLaytonContext _context;

    public EnigmasApiController(ProfessorLaytonContext context)
    {
        _context=context;
    }

        //GET : api/Charaters
    public async Task<ActionResult<IEnumerable<Enigma>>> GetEnigmas()
    {
        return await _context.Enigmas.ToListAsync();
    }


    [HttpPost]
    public async Task<ActionResult<Enigma>> PostEnigma(EnigmaDTO enigmaDTO)
    {
        Enigma enigma = new Enigma(enigmaDTO);

        // Lookup game
        var game = _context.Games.Find(enigma.GameId);

        // Define game for new enigma
        enigma.Game = game!;

        // Create new enigma in DB
        _context.Enigmas.Add(enigma);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostEnigma), new { id = enigma.Id }, enigma);
    }

    // PUT: api/EnigmaApi/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEnigma(int id, EnigmaDTO enigmaDTO)
    {
        if (id != enigmaDTO.Id)
            return BadRequest();

        Enigma enigma = new Enigma(enigmaDTO);

        // Lookup game
        var game = _context.Games.Find(enigma.GameId);

        // Define game for new enigma
        enigma.Game = game!;


        _context.Entry(enigma).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Enigmas.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }
}

