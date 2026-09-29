using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using System.Text;
using NetGameProjectBlazor.Components.Account.Identity.Models;
using NetGameProjectBlazor.Components.Account.Identity;
using System.Data;

namespace NetGameProjectBlazor.Components.Account.Pages.Identity
{
    public class CookieAuthenticationStateProvider : AuthenticationStateProvider, IAccountManagement
    {
        private bool _authenticated = false;

        private readonly ClaimsPrincipal Unauthenticated =
           new(new ClaimsIdentity());

        private readonly HttpClient _httpClient;


        private readonly JsonSerializerOptions jsonSerializerOptions =
          new()
          {
              PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
          };
        public CookieAuthenticationStateProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Auth");
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            _authenticated = false;

            // default to not authenticated
            var user = Unauthenticated;

            try
            {
                var userResponse = await _httpClient.GetAsync("manage/info");

                userResponse.EnsureSuccessStatusCode();

                var userJson = await userResponse.Content.ReadAsStringAsync();
                var userInfo = JsonSerializer.Deserialize<UserInfo>(userJson, jsonSerializerOptions);

                if (userInfo != null)
                {
                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.Name, userInfo.Email),
                        new(ClaimTypes.Email, userInfo.Email)
                    };

                    claims.AddRange(
                      userInfo.Claims.Where(c => c.Key != ClaimTypes.Name && c.Key != ClaimTypes.Email)
                          .Select(c => new Claim(c.Key, c.Value)));

                    var rolesResponse = await _httpClient.GetAsync($"api/Role/GetuserRole?userEmail={userInfo.Email}");

                    rolesResponse.EnsureSuccessStatusCode();

                    var rolesJson = await rolesResponse.Content.ReadAsStringAsync();

                    var roles = JsonSerializer.Deserialize<string[]>(rolesJson, jsonSerializerOptions);
                    if (roles != null && roles?.Length > 0)
                    {
                        foreach (var role in roles)
                        {
                            claims.Add(new(ClaimTypes.Role, role));
                        }
                    }

                    var id = new ClaimsIdentity(claims, nameof(CookieAuthenticationStateProvider));

                    user = new ClaimsPrincipal(id);

                    _authenticated = true;

                }
            }
            catch (Exception ex)
            {


            }

            return new AuthenticationState(user);

        }

        public async Task<FormResult> RegisterAsync(string email, string password)
        {
            string[] defaultDetail = ["An unknown error prevented registration from succeeding."];

            try
            {

                var result = await _httpClient.PostAsJsonAsync("register",
                      new { email, password });
                if (result.IsSuccessStatusCode)
                {
                    return new FormResult { Succeeded = true };
                }

                var details = await result.Content.ReadAsStringAsync();
                var problemDetails = JsonDocument.Parse(details);
                var errors = new List<string>();
                var errorList = problemDetails.RootElement.GetProperty("errors");

                foreach (var errorEntry in errorList.EnumerateObject())
                {
                    if (errorEntry.Value.ValueKind == JsonValueKind.String)
                    {
                        errors.Add(errorEntry.Value.GetString()!);
                    }
                    else if (errorEntry.Value.ValueKind == JsonValueKind.Array)
                    {
                        errors.AddRange(
                            errorEntry.Value.EnumerateArray().Select(
                                e => e.GetString() ?? string.Empty)
                            .Where(e => !string.IsNullOrEmpty(e)));
                    }
                }
                return new FormResult
                {
                    Succeeded = false,
                    ErrorList = problemDetails == null ? defaultDetail : [.. errors]
                };

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<FormResult> LoginAsync(string email, string password)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync(
                    "login?useCookies=true", new
                    {
                        email,
                        password
                    });

                if (result.IsSuccessStatusCode)
                {
                    NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
                    return new FormResult { Succeeded = true };
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return new FormResult
            {
                Succeeded = false,
                ErrorList = ["Invalid email and/or password."]
            };
        }

        public async Task LogoutAsync()
        {
            const string Empty = "{}";
            var emptyContent = new StringContent(Empty, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync("api/Account/Logout", emptyContent);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

        }

        public async Task<bool> CheckAuthenticatedAsync()
        {
            await GetAuthenticationStateAsync();
            return _authenticated;
        }


        public async Task<FormResult> AddRole(string[] roles)
        {
            try
            {
                var content = new StringContent(JsonSerializer.Serialize(roles), Encoding.UTF8, "application/json");
                var result = await _httpClient.PostAsync("api/Role/addRoles", content);

                if (result.IsSuccessStatusCode)
                {
                    return new FormResult { Succeeded = true };
                }


            }
            catch (Exception ex)
            {


            }
            return new FormResult
            {
                Succeeded = false,
                ErrorList = ["api has some issue"]
            };
        }


        public async Task<bool> Delete(string userEmailId)
        {
            try
            {
                var result = await _httpClient.DeleteAsync($"api/User/{userEmailId}");
                return result.IsSuccessStatusCode;

            }
            catch (Exception ex)
            {


            }

            return false;
        }
    }
}
