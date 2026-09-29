using Microsoft.EntityFrameworkCore;
using NetGameProjectBlazor.Context;
using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Interfaces;

namespace NetGameProjectBlazor.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly GardaNetGameContext _context;

        public GenreRepository(GardaNetGameContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Genre>> GetGenresForGameAsync(int gameId)
        {
            //return await _context.Genres
            //    .Where(g => g.Games.Any(game => game.Id == gameId))
            //    .ToListAsync();

            return await _context.Genres
                .Include(g => g.Games)
                .ThenInclude(g => g.Product)
               .Where(g => g.Games.Any(game => game.Product.Id == gameId))
               .ToListAsync();
        }
    }
}
