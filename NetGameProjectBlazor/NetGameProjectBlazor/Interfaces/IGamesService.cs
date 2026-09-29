using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Interfaces
{
    public interface IGamesService
    {
        Task<IEnumerable<GamesOverviewDto>> GetAllGamesAsync();
        Task<IEnumerable<GamesOverviewDto>> GetGamesByGenreAsync(string genre);
        Task<IEnumerable<GamesOverviewDto>> GetGamesByPriceAsync(decimal price);
        Task<IEnumerable<GamesOverviewDto>> GetGamesByAgeRestrictionAsync(int pegiID);
        Task<GameDetailDto> GetGameDetailsAsync(int gameId);
    }
}
