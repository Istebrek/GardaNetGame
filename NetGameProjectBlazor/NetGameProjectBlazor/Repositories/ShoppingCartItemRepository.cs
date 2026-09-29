using Microsoft.EntityFrameworkCore;
using NetGameProjectBlazor.Context;
using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Interfaces;

namespace NetGameProjectBlazor.Repositories;

public class ShoppingCartItemRepository : IShoppingCartItemRepository
{
    private readonly GardaNetGameContext _context;

    public ShoppingCartItemRepository(GardaNetGameContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));       
    }

    public async Task<ICollection<ShoppingCartItem>> GetCartItemsAsync(int cartId)
        => await _context.ShoppingCartItems
                .Include(p => p.Product)
                .Where(c => c.CartId == cartId)
                .ToListAsync();

    public async Task AddCartItemAsync(ShoppingCartItem item)
        => await _context.ShoppingCartItems.AddAsync(item);

    public void UpdateCartItem(ShoppingCartItem item)
        => _context.ShoppingCartItems.Update(item);

    public void DeleteCartItem(ShoppingCartItem item)
        => _context.ShoppingCartItems.Remove(item);

    public async Task<bool> SaveChangesAsync()
        => await _context.SaveChangesAsync() > 0;    
}