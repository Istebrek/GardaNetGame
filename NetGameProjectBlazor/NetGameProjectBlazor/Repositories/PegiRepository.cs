using Microsoft.EntityFrameworkCore;
using NetGameProjectBlazor.Context;
using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Interfaces;

namespace NetGameProjectBlazor.Repositories
{
    public class PegiRepository : IPegiRepository
    {
        private readonly GardaNetGameContext _context;

        public PegiRepository(GardaNetGameContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Pegi>> GetAllAgeRestrictionsAsync()
        {
            return await _context.Pegis.ToListAsync();
        }
    }
}
