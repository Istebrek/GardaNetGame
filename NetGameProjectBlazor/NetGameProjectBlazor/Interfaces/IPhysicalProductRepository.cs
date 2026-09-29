using NetGameProjectBlazor.Entities;

namespace NetGameProjectBlazor.Interfaces;

public interface IPhysicalProductRepository
{
    Task<IEnumerable<PhysicalProduct>> GetAllPhysicalProductsAsync();
    Task<PhysicalProduct?> GetPhysicalProducAsync(int id);
    Task NewPhysicalProductAsync(PhysicalProduct physicalProduct, Product product);
    Task<PhysicalProduct?> UpdatePhycialProductAsync(PhysicalProduct physicalProduct, Product product);
    Task<PhysicalProduct?> DeletePhysicalProductAsync(PhysicalProduct physicalProduct, Product product);
    Task<bool> AllowDeleteAsync(int id);
}