using Microsoft.EntityFrameworkCore;
using NetGameProjectBlazor.Context;
using NetGameProjectBlazor.Data;
using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Interfaces;

namespace NetGameProjectBlazor.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
    {
        return await _context.applicationUsers.ToListAsync();
    }

    public async Task<ApplicationUser?> GetUserAsync(string id)
    {
        return await _context.applicationUsers.FirstOrDefaultAsync(u => u.Id == id);
    }
}