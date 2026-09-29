using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Interfaces;

public interface IGenreService
{
    Task<IEnumerable<GenreForGameDto>> GetGenresForGameAsync(int gameId);
}
