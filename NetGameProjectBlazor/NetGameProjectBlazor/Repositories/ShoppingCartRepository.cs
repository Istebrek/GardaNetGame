using Microsoft.EntityFrameworkCore;
using NetGameProjectBlazor.Context;
using NetGameProjectBlazor.Data;
using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Interfaces;
using NetGameProjectBlazor.Shared.DTOs;
using static MudBlazor.CategoryTypes;

namespace NetGameProjectBlazor.Repositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly GardaNetGameContext _context;

    private readonly ApplicationDbContext _userContext;

    public ShoppingCartRepository(GardaNetGameContext context, ApplicationDbContext userContext)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
    }

    public async Task<ShoppingCart?> GetCartByIdAsync(int cartId)
        => await _context.ShoppingCarts
                 .Include(i => i.ShoppingCartItems)
                 .FirstOrDefaultAsync(c => c.Id == cartId);

    public async Task AddCartAsync(ShoppingCart cart)
        => await _context.ShoppingCarts.AddAsync(cart);

    public async Task<bool> SaveChangesAsync()
        => await _context.SaveChangesAsync() > 0;

	//public async Task<IEnumerable<ShoppingCart>> GetAllCartsAsync() => await _context.ShoppingCarts
	//	.Include(c => c.ShoppingCartItems)
	//	.ToListAsync();
	public async Task<IEnumerable<ShoppingCart>> GetAllCartsAsync()
	{
		return await _context.ShoppingCarts.ToListAsync();
	}
 //   public async Task<IEnumerable<ApplicationUser>> GetUsersAsync()
	//{
 //       return await _userContext.applicationUsers.ToListAsync();
	//}

}