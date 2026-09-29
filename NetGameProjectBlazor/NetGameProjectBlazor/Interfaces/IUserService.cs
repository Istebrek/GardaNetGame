using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto?> GetUserAsync(string id);

}