using BlazorWebAssemblyCrudDotNet8.Data;
using BlazorWebAssemblyCrudDotNet8.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAssemblyCrudDotNet8.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoGamesController : ControllerBase
{
    private DataContext _context;

    public VideoGamesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<VideoGame>>> GetAllVideoGamesAsync()
    {
        return await _context.VideoGames.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<VideoGame>>> GetGameByIdAsync(int id)
    {
        var result =  await _context.VideoGames.FindAsync(id);
        if (result is null)
            return NotFound("Jogo não encontrado");

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<List<VideoGame>>> AddGameByIdAsync(VideoGame newGame)
    {
        _context.Add(newGame);
        await _context.SaveChangesAsync();
        
        return Ok(newGame);
    }
    
    [HttpPut]
    public async Task<ActionResult<List<VideoGame>>> UpdateGameByIdAsync(VideoGame updateGame)
    {
        var result =  await _context.VideoGames.FindAsync(updateGame.Id);
        if (result is null)
            return NotFound("Jogo não encontrado");
        
        result.Title = updateGame.Title;
        result.Publisher = updateGame.Publisher;
        result.ReleaseYear = updateGame.ReleaseYear;

        _context.Entry(result).State = EntityState.Modified; 
        await _context.SaveChangesAsync();
        
        return Ok(updateGame);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteGameAsync(int id)
    {
        var result =  await _context.VideoGames.FindAsync(id);
        if (result is null)
            return NotFound("Jogo não encontrado");

        _context.VideoGames.Remove(result);
        await _context.SaveChangesAsync();
        return Ok();
    }
    
}