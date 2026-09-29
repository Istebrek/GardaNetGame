using AutoMapper;
using NetGameProjectBlazor.Interfaces;
using NetGameProjectBlazor.Repositories;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var userEntities = await _userRepository.GetAllUsersAsync();

        if (userEntities == null)
        {
            return null;
        }

        return _mapper.Map<IEnumerable<UserDto>>(userEntities);
    }

    public async Task<UserDto?> GetUserAsync(string id)
    {
        var user = await _userRepository.GetUserAsync(id);
        if (user == null) return null;
        return _mapper.Map<UserDto?>(user);
    }

}