using NetGameProjectBlazor.Entities;

namespace NetGameProjectBlazor.Interfaces
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetGenresForGameAsync(int gameId);
    }
}
