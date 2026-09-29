using NetGameProjectBlazor.Entities;

namespace NetGameProjectBlazor.Interfaces
{
    public interface IGamesRepository
    {
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<IEnumerable<Game>> GetGamesByGenreAsync(string genre);
        Task<IEnumerable<Game>> GetGamesByPriceAsync(decimal price);
        Task<IEnumerable<Game>> GetGamesByAgeRestrctionAsync(int pegiId);
        Task<Game> GetGameDetailsAsync(int gameId);
    
    }
}
