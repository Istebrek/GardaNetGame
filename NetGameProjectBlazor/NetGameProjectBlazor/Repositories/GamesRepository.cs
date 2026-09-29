using Microsoft.EntityFrameworkCore;
using NetGameProjectBlazor.Context;
using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Interfaces;

namespace NetGameProjectBlazor.Repositories
{
    public class GamesRepository : IGamesRepository
    {
        private readonly GardaNetGameContext _context;

        public GamesRepository(GardaNetGameContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return await _context.Games.Include(g => g.Product).ToListAsync();
        }

        public async Task<Game> GetGameDetailsAsync(int gameId)
        {
            return await _context.Games
                .Include(g => g.Product)
                .Where(g => g.Product.Id == gameId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Game>> GetGamesByAgeRestrctionAsync(int pegiId)
        {
            return await _context.Games
                .Include(g => g.Product)
                .Where(g => g.Pegi.Id == pegiId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Game>> GetGamesByGenreAsync(string genre)
        {
            return await _context.Games
                .Include(g => g.Product)
                .Where(g => g.Genres.Any(genreItem => genreItem.Name == genre))
                .ToListAsync();
                
        }

        public async Task<IEnumerable<Game>> GetGamesByPriceAsync(decimal price)
        {
            return await _context.Games
                .Include(g => g.Product)
                .Where(g => g.Product.Price <= price)
                .ToListAsync();
        }
    } 
}
