using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfessorLayton.Data;
using ProfessorLayton.Models;
 
namespace ProfessorLayton.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SolutionApiController : ControllerBase
{
    private readonly ProfessorLaytonContext _context;

    public SolutionApiController(ProfessorLaytonContext context)
    {
        _context=context;
    }

        //GET : api/Charaters
    public async Task<ActionResult<IEnumerable<Solution>>> GetSolutions()
    {
        return await _context.Solutions.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Solution>> PostSolution(SolutionDTO solutionDTO)
    {
        Solution solution = new Solution(solutionDTO);
        var latestEnigmaId=(from e in _context.Enigmas select e.Id).Max();
        solution.EnigmaId=latestEnigmaId;
        // Lookup enigma
        var enigma = _context.Enigmas.Find(solution.EnigmaId);

        // Define enigma for new solution
        solution.Enigma = enigma!;

        // Create new solution in DB
        _context.Solutions.Add(solution);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostSolution), new { id = solution.Id }, solution);
    }

    // // PUT: api/EnigmaApi/5
    // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // [HttpPut("{id}")]
    // public async Task<IActionResult> PutEnigma(int id, EnigmaDTO enigmaDTO)
    // {
    //     if (id != enigmaDTO.Id)
    //         return BadRequest();

    //     Enigma enigma = new Enigma(enigmaDTO);

    //     // Lookup game
    //     var game = _context.Games.Find(enigma.GameId);

    //     // Define game for new enigma
    //     enigma.Game = game!;


    //     _context.Entry(enigma).State = EntityState.Modified;

    //     try
    //     {
    //         await _context.SaveChangesAsync();
    //     }
    //     catch (DbUpdateConcurrencyException)
    //     {
    //         if (!_context.Enigmas.Any(m => m.Id == id))
    //             return NotFound();
    //         else
    //             throw;
    //     }

    //     return NoContent();
    // }
}

