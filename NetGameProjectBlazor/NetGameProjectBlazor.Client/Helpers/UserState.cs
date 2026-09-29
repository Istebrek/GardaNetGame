using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Client.Helpers;

public class UserState(AuthenticationStateProvider authStateProvider, HttpClient httpClient)
{
    public bool IsSignedIn { get; set; }
    public string? UserId { get; set; }
    public int CartId { get; set; }

    public async Task GetUserInfo()
    {
        if (IsSignedIn && UserId is not null)
        {
            return;
        }
        var authState = await authStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity?.IsAuthenticated == true)
        {
            IsSignedIn = true;
            UserId = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            CartId = await GetUserCartId();
        }
    }

    private async Task<int> GetUserCartId()
    {
        var carts = await httpClient.GetFromJsonAsync<IEnumerable<ShoppingCartDto>>("api/cart");
        if (carts is null)
        {
            return await CreateUserCart();
        }
        var userCart = carts.FirstOrDefault(x => x.CustomerId == UserId);

        if (userCart is null)
        {
            await CreateUserCart();
        }
        return userCart!.Id;
    }

    private async Task<int> CreateUserCart()
    {
        var newCart = new ShoppingCartCreateDto
        {
            CustomerId = UserId,
            CreatedAt = DateTime.Now
        };
        var response = await httpClient.PostAsJsonAsync("api/cart", newCart);

        if (response.IsSuccessStatusCode)
        {
            var createdCart = await response.Content.ReadFromJsonAsync<ShoppingCartDto>();

            if (createdCart is null)
            {
                return 0;
            }
            return createdCart.Id;
        }
        return response.Content.ReadFromJsonAsync<ShoppingCartDto>().Id;
    }
}