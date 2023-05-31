using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfessorLayton.Data;
using ProfessorLayton.Models;
 
namespace ProfessorLayton.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HintsApiController : ControllerBase
{
    private readonly ProfessorLaytonContext _context;

    public HintsApiController(ProfessorLaytonContext context)
    {
        _context=context;
    }

    //GET : api/Hints
    public async Task<ActionResult<IEnumerable<Hint>>> GetHints()
    {
        return await _context.Hints.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Solution>> PostHint(HintDTO hintDTO)
    {
        Hint hint=new Hint(hintDTO);
        var latestEnigmaId=(from e in _context.Enigmas select e.Id).Max();
        hint.EnigmaId=latestEnigmaId;
        // Lookup enigma
        var enigma = _context.Enigmas.Find(hint.EnigmaId);

        // Define enigma for new solution
        hint.Enigma = enigma!;

        // Create new solution in DB
        _context.Hints.Add(hint);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostHint), new { id = hint.Id }, hint);
    }
}