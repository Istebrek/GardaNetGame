using AutoMapper;
using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Interfaces;
using NetGameProjectBlazor.Repository;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Services;

public class PhysicalProductsService : IPhysicalProductService
{
    private readonly IPhysicalProductRepository _physicalProductRepository;
    private readonly IMapper _mapper;

    public PhysicalProductsService(IPhysicalProductRepository physicalProductRepository,
        IMapper mapper)
    {
        _physicalProductRepository = physicalProductRepository
            ?? throw new ArgumentNullException(nameof(physicalProductRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }        

    public async Task<IEnumerable<PhysicalProductDto>> GetAllPhysicalProductsAsync()
    {
        try
        {
            var products = await _physicalProductRepository.GetAllPhysicalProductsAsync();
            return _mapper.Map<IEnumerable<PhysicalProductDto>>(products);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<PhysicalProductDto?> GetPhysicalProducAsync(int id)
    {
        var product = await _physicalProductRepository.GetPhysicalProducAsync(id);
        return _mapper.Map<PhysicalProductDto>(product);
    }

    public async Task<PhysicalProductDto?> DeletePhysicalProductAsync(PhysicalProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        var physicalProduct = _mapper.Map<PhysicalProduct>(productDto);

        var allowDelete = await _physicalProductRepository.AllowDeleteAsync(product.Id);
        if (allowDelete)
        {
            var p = await _physicalProductRepository.DeletePhysicalProductAsync(physicalProduct, product);
            PhysicalProductDto dp =_mapper.Map<PhysicalProductDto>(p);
            return dp == null ? dp : null;
        }
        return null;

    }

    public async Task NewPhysicalProductAsync(PhysicalProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        var physicalProduct = _mapper.Map<PhysicalProduct>(productDto);
        await _physicalProductRepository.NewPhysicalProductAsync(physicalProduct, product);
    }

    public async Task<PhysicalProductDto?> UpdatePhycialProductAsync(PhysicalProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        var physicalProduct = _mapper.Map<PhysicalProduct>(productDto);
        var updatedProduct = await _physicalProductRepository.UpdatePhycialProductAsync(physicalProduct, product);
        return _mapper.Map<PhysicalProductDto>(updatedProduct);
    }
}
