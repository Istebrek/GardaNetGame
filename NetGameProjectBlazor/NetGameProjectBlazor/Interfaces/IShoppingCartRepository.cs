using NetGameProjectBlazor.Data;
using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Interfaces;

public interface IShoppingCartRepository
{
    Task<ShoppingCart?> GetCartByIdAsync(int cartId);
    Task AddCartAsync(ShoppingCart cart);
    Task<bool> SaveChangesAsync();
	//Task <IEnumerable<ShoppingCart>> GetAllCartsAsync();
	Task<IEnumerable<ShoppingCart>> GetAllCartsAsync();
    //Task<IEnumerable<ApplicationUser>> GetUsersAsync();
}
