using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetGameProjectBlazor.Interfaces;
using NetGameProjectBlazor.Services;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Controllers;

[ApiController]
[Route("api/games")]
public class GameController : ControllerBase
{
    private readonly IGamesRepository _gamesRepository;
    private readonly IMapper _mapper;
    private readonly IGamesService _gamesService;

    public GameController(IGamesRepository gamesRepository, IMapper mapper, IGamesService gamesService)
    {
        _gamesRepository = gamesRepository ?? throw new ArgumentNullException(nameof(gamesRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _gamesService = gamesService ?? throw new ArgumentNullException(nameof(gamesService));
    }

    [HttpGet]
    public async Task <ActionResult<IEnumerable<GamesOverviewDto>>> GetAllGames()
    {
        var games = await _gamesService.GetAllGamesAsync();

        if (games == null || !games.Any())
        {
            return NotFound("Inga spel hittades.");
        }

        return Ok(games);
    }

    [HttpGet("details/{gameId}", Name = "GetGameDetails")]
    public async Task<ActionResult<GameDetailDto>> GetGameDetails(int gameId)
    {
        var game = await _gamesService.GetGameDetailsAsync(gameId);

        if (game == null)
        {
            return NotFound($"Spel med id {gameId} hittades inte.");
        }

        return Ok(game);
    }

    [HttpGet("by-genre/{genre}", Name = "GetGamesByGenre")]
    public async Task <ActionResult<IEnumerable<GamesOverviewDto>>> GetGamesByGenre(string genre)
    {
        var games = await _gamesService.GetGamesByGenreAsync(genre);

        if (games == null || !games.Any())
        {
            return NotFound($"Inga spel med genre {genre} hittades.");
        }

        return Ok(games);
    }

    [HttpGet("by-price/{price}", Name = "GetGamesByPrice")]
    public async Task <ActionResult<IEnumerable<GamesOverviewDto>>> GetGamesByPrice(decimal price)
    {
        var games = await _gamesService.GetGamesByPriceAsync(price);

        if (games == null || !games.Any())
        {
            return NotFound($"Inga spel under {price} kr hittades.");
        }

        return Ok(games);
    }

    [HttpGet("by-age/{pegiId}", Name = "GetGamesByAgeRestriction")]
    public async Task<ActionResult<IEnumerable<GamesOverviewDto>>> GetGamesByAgeRestriction(int pegiId)
    {
        var games = await _gamesService.GetGamesByAgeRestrictionAsync(pegiId);

        if (games == null || !games.Any())
        {
            return NotFound($"Inga spel med åldersgräns {pegiId} eller under hittades.");
        }

        return Ok(games);
    }

}
