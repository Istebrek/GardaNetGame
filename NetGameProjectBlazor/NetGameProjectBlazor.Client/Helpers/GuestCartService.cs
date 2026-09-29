using System.Text.Json;
using Microsoft.JSInterop;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Client.Helpers;

public class GuestCartService(IJSRuntime js)
{
    private const string Key = "guestCart";

    public async Task<ShoppingCartDto> GetAsync()
    {
        try
        {
            var json = await js.InvokeAsync<string?>("localStorage.getItem", Key);
            var cart = string.IsNullOrEmpty(json)
                ? null
                : JsonSerializer.Deserialize<ShoppingCartDto>(json);

            cart ??= new ShoppingCartDto();
            cart.ShoppingCartItems ??= [];
            return cart;
        }
        catch
        {
            return new ShoppingCartDto { ShoppingCartItems = [] };
        }
    }

    public async Task AddAsync(ShoppingCartItemDto item)
    {
        var cart = await GetAsync();
        var existing = cart.ShoppingCartItems.FirstOrDefault(x => x.ProductId == item.ProductId);

        if (existing is null) cart.ShoppingCartItems.Add(item);
        else existing.Quantity += item.Quantity;

        await SaveAsync(cart);
    }

    public async Task SetQuantityAsync(int productId, int quantity)
    {
        var cart = await GetAsync();
        var existing = cart.ShoppingCartItems.FirstOrDefault(x => x.ProductId == productId);
        if (existing is null) return;

        if (quantity < 1) await RemoveAsync(existing.ProductId);
        else existing.Quantity = quantity;

        await SaveAsync(cart);
    }

    public async Task RemoveAsync(int productId)
    {
        var cart = await GetAsync();
        cart.ShoppingCartItems.RemoveAll(x => x.ProductId == productId);
        await SaveAsync(cart);
    }

    public Task ClearAsync() => js.InvokeVoidAsync("localStorage.removeItem", Key).AsTask();

    private Task SaveAsync(ShoppingCartDto cart) =>
        js.InvokeVoidAsync("localStorage.setItem", Key, JsonSerializer.Serialize(cart)).AsTask();
}