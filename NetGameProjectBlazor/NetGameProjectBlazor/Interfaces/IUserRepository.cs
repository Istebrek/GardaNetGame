using NetGameProjectBlazor.Data;
using NetGameProjectBlazor.Entities;

namespace NetGameProjectBlazor.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
    Task<ApplicationUser?> GetUserAsync(string id);
}