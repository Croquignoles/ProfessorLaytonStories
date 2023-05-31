using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfessorLayton.Models;
using ProfessorLayton.Data;

namespace ProfessorLayton.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamesApiController : ControllerBase
{
    private readonly ProfessorLaytonContext _context=null!;

    public GamesApiController(ProfessorLaytonContext context)
    {
        _context=context;
    }

    //GET : api/Games
    public async Task<ActionResult<IEnumerable<Game>>> GetGames()
    {
        return await _context.Games.ToListAsync();
    }
    // GET: api/Games/Id
    [HttpGet("{id}")]
    public async Task<ActionResult<Game>> GetGame(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null)
            return NotFound();
        return game;
    }
}