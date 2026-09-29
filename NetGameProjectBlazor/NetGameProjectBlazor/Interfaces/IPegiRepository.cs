

using NetGameProjectBlazor.Entities;

namespace NetGameProjectBlazor.Interfaces
{
    public interface IPegiRepository
    {
        Task<IEnumerable<Pegi>> GetAllAgeRestrictionsAsync();
    }
}
