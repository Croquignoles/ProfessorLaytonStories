using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfessorLayton.Models;
using ProfessorLayton.Data;

namespace ProfessorLayton.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MusicsApiController : ControllerBase
{
    private readonly ProfessorLaytonContext _context=null!;

    public MusicsApiController(ProfessorLaytonContext context)
    {
        _context=context;
    }

    //GET : api/Musics 
public async Task<ActionResult<IEnumerable<Music>>> GetMusics()
    {
        return await _context.Musics
        .ToListAsync();
    }
    // GET: api/Musics/Id
    [HttpGet("{id}")]
    public async Task<ActionResult<Music>> GetMusic(int id)
    {
        var music = await _context.Musics.FindAsync(id);
        if (music == null)
            return NotFound();
        return music;
    }

    //POST : api/Musics
    [HttpPost]
    public async Task<ActionResult<Music>> PostMusic(Music musicDTO)
    {
        Music music=new Music(musicDTO);
        _context.Musics.Add(music);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMusic),new{id=music.Id},music);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMusic(int id, Music music)
    {
        if (id != music.Id)
            return BadRequest();

        _context.Entry(music).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MusicExists(id))
                return NotFound();
            else
                throw;
        }
        return NoContent();
    }

    // Returns true if a music with specified id already exists
    private bool MusicExists(int id)
    {
        return _context.Musics.Any(m => m.Id == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMusic(int id)
    {
        var music = await _context.Musics.FindAsync(id);
        if (music == null)
            return NotFound();

        _context.Musics.Remove(music);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}