using Microsoft.EntityFrameworkCore;
using NetGameProjectBlazor.Context;
using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Interfaces;

namespace NetGameProjectBlazor.Repository;

public class PhysicalProductRepository : IPhysicalProductRepository
{
    private readonly GardaNetGameContext _context ;

    public PhysicalProductRepository(GardaNetGameContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }    

    public async Task<PhysicalProduct?> DeletePhysicalProductAsync(PhysicalProduct physicalProduct, Product product)
    {
        var p = await _context.PhysicalProducts.FirstOrDefaultAsync(p => p.ProductId == physicalProduct.ProductId);
        if (p != null)
        {
            _context.PhysicalProducts.Remove(physicalProduct);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return p;
        }
        return null;
    }

    public async Task<IEnumerable<PhysicalProduct>> GetAllPhysicalProductsAsync() => 
        await _context.PhysicalProducts.Include(p => p.Product).ToListAsync();


    public async Task<PhysicalProduct?> GetPhysicalProducAsync(int id) =>
         await _context.PhysicalProducts.Include(p => p.Product).FirstOrDefaultAsync(p => p.ProductId == id);

    public async Task NewPhysicalProductAsync(PhysicalProduct physicalProduct, Product product)
    {
        _context.Products.Add(product);
        _context.PhysicalProducts.Add(physicalProduct);
        await _context.SaveChangesAsync();
    }

    public async Task<PhysicalProduct?> UpdatePhycialProductAsync(PhysicalProduct physicalProduct, Product product)
    {
        var updateProduct = await _context.PhysicalProducts
            .Include(p => p.Product)
            .FirstOrDefaultAsync(p => p.ProductId == physicalProduct.ProductId);
        if (updateProduct != null)
        {
            updateProduct.Product.Name = product.Name;
            updateProduct.Product.Description = product.Description;
            updateProduct.Product.Price = product.Price;
            updateProduct.Product.ProductImageUrl = product.ProductImageUrl;
            updateProduct.Product.IsActive = product.IsActive;
            updateProduct.Product.Game = product.Game ?? updateProduct.Product.Game;
            updateProduct.Product.OrderItems = product.OrderItems ?? updateProduct.Product.OrderItems;
            updateProduct.StockQuantity = physicalProduct.StockQuantity;

            await _context.SaveChangesAsync();
            return updateProduct;
        }
        return null;
    }
    public async Task<bool> AllowDeleteAsync(int id) // Lägg till mer logik här för att ändra reglerna för att radera
    {
        var existProduct = await _context.PhysicalProducts.Include(p => p.Product).FirstOrDefaultAsync(p => p.ProductId == id);
        return existProduct == null ? false : true;
    }
}
