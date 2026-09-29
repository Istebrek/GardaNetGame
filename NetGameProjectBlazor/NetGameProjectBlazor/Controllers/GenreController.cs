using Microsoft.AspNetCore.Mvc;
using NetGameProjectBlazor.Interfaces;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Controllers;

[ApiController]
[Route("api/genres")]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenreController(IGenreService genreService)
    {
        _genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
    }

    [HttpGet("genre-for-games/{gameId}", Name = "GetGenresForGame")]
    public async Task<ActionResult<GenreForGameDto>> GetGenresForGame(int gameId)
    {
        var genres = await _genreService.GetGenresForGameAsync(gameId);

        if (genres == null)
        {
            return NotFound($"Kunde ej hitta genre för spel med id {gameId}");
        }

        return Ok(genres);
    }
}
