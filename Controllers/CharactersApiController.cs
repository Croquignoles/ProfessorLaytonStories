using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfessorLayton.Models;
using ProfessorLayton.Data;

namespace ProfessorLayton.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CharactersApiController : ControllerBase
{
    private readonly ProfessorLaytonContext _context=null!;

    public CharactersApiController(ProfessorLaytonContext context)
    {
        _context=context;
    }

    //GET : api/Charaters
    public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
    {
        return await _context.Characters.ToListAsync();
    }
    // GET: api/Characters/Id
    [HttpGet("{id}")]
    public async Task<ActionResult<Character>> GetCharacter(int id)
    {
        var character = await _context.Characters.FindAsync(id);
        if (character == null)
            return NotFound();
        return character;
    }
}