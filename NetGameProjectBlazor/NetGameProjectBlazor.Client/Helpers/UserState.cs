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
            return 0;
        }
        var userCart = carts.FirstOrDefault(x => x.CustomerId == UserId);

        if (userCart is null)
        {
            var response = await httpClient.PostAsJsonAsync<ShoppingCartCreateDto>($"api/cart", new ShoppingCartCreateDto
            {
                CustomerId = UserId,
                CreatedAt = DateTime.Now,
                ShoppingCartItems = []
            });

            if (response.IsSuccessStatusCode)
            {
                var newCart = await response.Content.ReadFromJsonAsync<ShoppingCartDto>();

                if (newCart is null)
                {
                    return 0;
                }
                return newCart.Id;
            }
            return 0;
        }

        return userCart.Id;
    }
}