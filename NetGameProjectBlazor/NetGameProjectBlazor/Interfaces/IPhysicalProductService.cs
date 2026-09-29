using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Interfaces
{
    public interface IPhysicalProductService
    {
        Task<IEnumerable<PhysicalProductDto>> GetAllPhysicalProductsAsync();
        Task<PhysicalProductDto?> GetPhysicalProducAsync(int id);
        Task NewPhysicalProductAsync(PhysicalProductDto productDto);
        Task<PhysicalProductDto?> UpdatePhycialProductAsync(PhysicalProductDto productDto);
        Task<PhysicalProductDto?> DeletePhysicalProductAsync(PhysicalProductDto productDto);
    }
}
