using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Interfaces;

public interface IShoppingCartService
{
    Task<ShoppingCartDto> GetShoppingCartByIdAsync(int cartId);
    Task<ShoppingCartDto> CreateShoppingCartAsync(ShoppingCartCreateDto newCart);
    Task<bool> ClearShoppingCart(int cartId);
    Task<ShoppingCartDto> AddShoppingCartItemAsync(int cartId, ShoppingCartItemCreateDto newCartItem);
    Task<ShoppingCartDto> UpdateShoppingCartItemAsync(int cartId, ShoppingCartItemUpdateDto cartItemToUpdate);
    Task<ShoppingCartDto> RemoveShoppingCartItem(int cartId, int cartItemId);

	//Task<IEnumerable<ShoppingCartDto>> GetAllCartsAsync();
	Task<IEnumerable<ShoppingCartDto>> GetAllCartsAsync();
	//Task<IEnumerable<ShoppingCartDto>> GetUsersAsync();
}
