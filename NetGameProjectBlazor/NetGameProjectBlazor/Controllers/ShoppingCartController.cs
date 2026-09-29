using Microsoft.AspNetCore.Mvc;
using NetGameProjectBlazor.Interfaces;
using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Shared.DTOs;
using static MudBlazor.CategoryTypes;

namespace NetGameProjectBlazor.Controllers;

[ApiController]
[Route("api/cart")]
public class ShoppingCartController : ControllerBase
{
    private readonly IShoppingCartService _shoppingCartService;

    public ShoppingCartController(IShoppingCartService shoppingCartService)
    {
        _shoppingCartService = shoppingCartService
            ?? throw new ArgumentNullException(nameof(shoppingCartService));
    }

	[HttpGet]
	public async Task<ActionResult<IEnumerable<ShoppingCartDto>>> GetAllCartsAsync()
	{
		var carts = await _shoppingCartService.GetAllCartsAsync();

		return carts is null || !carts.Any()
			? NotFound("No shopping carts found.")
			: Ok(carts);
	}

	[HttpGet("{cartId}", Name = "GetCartById")]
	public async Task<ActionResult<ShoppingCartDto>> GetCartByIdAsync(int cartId)
    {
        var cart = await _shoppingCartService.GetShoppingCartByIdAsync(cartId);

        return (cart is null)
            ? NotFound($"No shopping cart found with given ID: {cartId}.")
            : Ok(cart);
    }

    [HttpPost]
    public async Task<ActionResult<ShoppingCartDto>> CreateCartAsync(ShoppingCartCreateDto newCart)
    {
        if (newCart is null)
        {
            return BadRequest("Invalid cart data, please try again.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newlyCreatedCart = await _shoppingCartService.CreateShoppingCartAsync(newCart);

        return (newlyCreatedCart is null)
            ? StatusCode(500, $"Failed to create shopping cart due to an unexpected issue.")
            : CreatedAtAction(
	"GetCartById", // <- matches the Name property
	new { cartId = newlyCreatedCart.Id },
	newlyCreatedCart);
	}

    [HttpDelete("{cartId}")]
    public async Task<ActionResult> ClearCartAsync(int cartId)
    {
        var result = await _shoppingCartService.ClearShoppingCart(cartId);

        return result is true
            ? NoContent()
            : NotFound($"No shopping cart found with given ID: {cartId}.");
    }

    [HttpPost("item/{cartId}")]
    public async Task<ActionResult<ShoppingCartDto>> AddShoppingCartItemAsync(int cartId, ShoppingCartItemCreateDto newCartItem)
    {
        if (newCartItem is null)
        {
            return BadRequest("Invalid cart item data, please try again.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedCart = await _shoppingCartService.AddShoppingCartItemAsync(cartId, newCartItem);

        return updatedCart is null
            ? StatusCode(500, $"A problem occurred while adding selected product to shopping cart.")
            : CreatedAtAction("GetCartById", new { cartId = updatedCart.Id }, updatedCart);
    }

    [HttpPut("item/{cartId}")]
    public async Task<ActionResult<ShoppingCartDto>> UpdateShoppingCartItemAsync(int cartId, ShoppingCartItemUpdateDto cartItemToUpdate)
    {
        if (cartItemToUpdate is null)
        {
            return BadRequest("Invalid cart item data, please try again.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedCart = await _shoppingCartService.UpdateShoppingCartItemAsync(cartId, cartItemToUpdate);

        return updatedCart is null
            ? StatusCode(500, $"A problem occurred while updating product quantity in shopping cart.")
            : Ok(updatedCart);
    }

    [HttpDelete("item/{cartId}/{cartItemId}")]
    public async Task<ActionResult<ShoppingCartDto>> RemoveShoppingCartItem(int cartId, int cartItemId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedCart = await _shoppingCartService.RemoveShoppingCartItem(cartId, cartItemId);

        return updatedCart is null
            ? StatusCode(500, $"A problem occurred while trying to remove selected product from shopping cart.")
            : Ok(updatedCart);
    }
}


