

using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Interfaces
{
    public interface IPegiService
    {
        Task<IEnumerable<PegiNameDto>> GetAllAgeRestrictionsAsync();
    }
}
