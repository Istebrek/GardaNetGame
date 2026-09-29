using NetGameProjectBlazor.Entities;

namespace NetGameProjectBlazor.Interfaces;

public interface IShoppingCartItemRepository
{
    Task<ICollection<ShoppingCartItem>> GetCartItemsAsync(int cartId);
    Task AddCartItemAsync(ShoppingCartItem item);
    void UpdateCartItem(ShoppingCartItem item);
    void DeleteCartItem(ShoppingCartItem item);
    Task<bool> SaveChangesAsync();
}