using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetGameProjectBlazor.Context;
using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Interfaces;
using NetGameProjectBlazor.Shared.DTOs;
using static MudBlazor.CategoryTypes;

namespace NetGameProjectBlazor.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly IShoppingCartItemRepository _shoppingCartItemRepository;
    private readonly IUserRepository _userRepository;
    private readonly GardaNetGameContext _context;

	private readonly IMapper _mapper;

    public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, 
        IShoppingCartItemRepository shoppingCartItemRepository, IMapper mapper, 
        IUserRepository userRepository, GardaNetGameContext context)
    {
        _shoppingCartRepository = shoppingCartRepository 
            ?? throw new ArgumentNullException(nameof(shoppingCartRepository));
        _shoppingCartItemRepository = shoppingCartItemRepository
            ?? throw new ArgumentNullException(nameof(shoppingCartItemRepository));
        _mapper = mapper 
            ?? throw new ArgumentNullException(nameof(mapper));
        _context = context
            ?? throw new ArgumentNullException(nameof(context));
        _userRepository = userRepository
            ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<ShoppingCartDto> GetShoppingCartByIdAsync(int cartId)
    {
        var cart = await _shoppingCartRepository.GetCartByIdAsync(cartId);

        if (cart is null)
        {
            return null;
        }

        var cartItems = await _shoppingCartItemRepository.GetCartItemsAsync(cartId);

        cart.ShoppingCartItems = cartItems;

        return _mapper.Map<ShoppingCartDto>(cart);
    }
 //   public async Task<IEnumerable <ShoppingCartDto>> GetUsersAsync()
 //   {
 //       var customers = await _shoppingCartRepository.GetUsersAsync();
 //       return _mapper.Map<IEnumerable<ShoppingCartDto>>(customers);
	//}

	public async Task<ShoppingCartDto> CreateShoppingCartAsync(ShoppingCartCreateDto newCart)
    {
		var user = await _userRepository.GetUserAsync(newCart.CustomerId);
		if (user is null)
			throw new Exception($"User not found: {newCart.CustomerId}");

		// Check if user already has a cart
		var existingCart = await _context.ShoppingCarts
			.FirstOrDefaultAsync(c => c.CustomerId == newCart.CustomerId);

		if (existingCart is not null)
			return _mapper.Map<ShoppingCartDto>(existingCart);

		// Map and create new cart
		var cart = _mapper.Map<ShoppingCart>(newCart);
		cart.CreatedAt = DateTime.UtcNow;

		_context.ShoppingCarts.Add(cart);
		await _context.SaveChangesAsync();

		return _mapper.Map<ShoppingCartDto>(cart);
		    
	}

    public async Task<bool> ClearShoppingCart(int cartId)
    {
        var cart = await _shoppingCartRepository.GetCartByIdAsync(cartId);

        if (cart is null)
        {
            return false;
        }

        var cartItems = await _shoppingCartItemRepository.GetCartItemsAsync(cartId);

        if (cartItems is null || cartItems.Count() <= 0)
        {
            return false;
        }

        foreach (var item in cartItems)
        {
            _shoppingCartItemRepository.DeleteCartItem(item);
        }

        await _shoppingCartItemRepository.SaveChangesAsync();

        return true;
    }
    
    public async Task<ShoppingCartDto> AddShoppingCartItemAsync(int cartId, ShoppingCartItemCreateDto newCartItem)
    {
        var cart = await _shoppingCartRepository.GetCartByIdAsync(cartId);

        if (cart is null)
        {
            return null;
        }

        var cartItems = await _shoppingCartItemRepository.GetCartItemsAsync(cart.Id);

        var existingCartItem = cartItems.FirstOrDefault(i => i.ProductId == newCartItem.ProductId);

        if (existingCartItem is null)
        {
            var cartItem = _mapper.Map<ShoppingCartItem>(newCartItem);

            cartItem.CartId = cart.Id;
            
            await _shoppingCartItemRepository.AddCartItemAsync(cartItem);
        }
        else
        {
            existingCartItem.Quantity++;

            _shoppingCartItemRepository.UpdateCartItem(existingCartItem);
        }
        
        await _shoppingCartItemRepository.SaveChangesAsync();

        var updatedCart = await _shoppingCartRepository.GetCartByIdAsync(cart.Id);

        return _mapper.Map<ShoppingCartDto>(updatedCart);
    }

    public async Task<ShoppingCartDto> UpdateShoppingCartItemAsync(int cartId, ShoppingCartItemUpdateDto cartItemToUpdate)
    {
        var cart = await _shoppingCartRepository.GetCartByIdAsync(cartId);

        if (cart is null)
        {
            return null;
        }

        var cartItems = await _shoppingCartItemRepository.GetCartItemsAsync(cart.Id);

        var existingCartItem = cartItems.FirstOrDefault(i => i.Id == cartItemToUpdate.Id);

        if (existingCartItem is null)
        {
            return null;
        }

        if (cartItemToUpdate.Quantity <= 0)
        {
            await RemoveShoppingCartItem(cartId, existingCartItem.Id);
        }
        else
        {
            _mapper.Map(cartItemToUpdate, existingCartItem);

            _shoppingCartItemRepository.UpdateCartItem(existingCartItem);
        }

        await _shoppingCartItemRepository.SaveChangesAsync();

        var updatedCart = await _shoppingCartRepository.GetCartByIdAsync(cart.Id);

        return _mapper.Map<ShoppingCartDto>(updatedCart);
    }
	public async Task<IEnumerable<ShoppingCartDto>> GetAllCartsAsync()
	{
		var carts = await _shoppingCartRepository.GetAllCartsAsync();
		return _mapper.Map<IEnumerable<ShoppingCartDto>>(carts);
	}

	//   public async Task <IEnumerable<ShoppingCartDto>> GetAllCartsAsync ()
	//   {
	//	var cart = await _shoppingCartRepository.GetAllCartsAsync();

	//       if (cart is null || !cart.Any())
	//	{
	//		return Enumerable.Empty<ShoppingCartDto>();
	//	}

	//	return _mapper.Map<IEnumerable<ShoppingCartDto>>(cart);
	//}
	public async Task<ShoppingCartDto> RemoveShoppingCartItem(int cartId, int cartItemId)
    {
        var cart = await _shoppingCartRepository.GetCartByIdAsync(cartId);

        if (cart is null)
        {
            return null;
        }

        var cartItems = await _shoppingCartItemRepository.GetCartItemsAsync(cartId);

        var itemToDelete = cartItems.FirstOrDefault(i => i.Id == cartItemId);

        if (itemToDelete is null)
        {
            return null;
        }

        _shoppingCartItemRepository.DeleteCartItem(itemToDelete);
       
        await _shoppingCartItemRepository.SaveChangesAsync();

        var updatedCart = await _shoppingCartRepository.GetCartByIdAsync(cart.Id);

        return _mapper.Map<ShoppingCartDto>(updatedCart);
    }
}
