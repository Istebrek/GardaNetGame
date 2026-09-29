using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using NetGameProjectBlazor.Client.Helpers;
using NetGameProjectBlazor.Client.Pages;
using NetGameProjectBlazor.Components;
using NetGameProjectBlazor.Components.Account;
using NetGameProjectBlazor.Components.Account.Identity;
using NetGameProjectBlazor.Components.Account.Pages.Identity;
using NetGameProjectBlazor.Context;
using NetGameProjectBlazor.Data;
using NetGameProjectBlazor.Interfaces;
using NetGameProjectBlazor.Repositories;
using NetGameProjectBlazor.Repository;
using NetGameProjectBlazor.Services;

namespace NetGameProjectBlazor;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddMudServices();

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveWebAssemblyComponents();

        builder.Services.AddScoped<UserState>();
        builder.Services.AddScoped<GuestCartService>();
        

        /*builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend", policy =>
            {
                policy.WithOrigins("https://localhost:7141")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });*/


        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddScoped<IdentityUserAccessor>();
        builder.Services.AddScoped<IdentityRedirectManager>();
        builder.Services.AddScoped<AuthenticationStateProvider, PersistingServerAuthenticationStateProvider>();

        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        })
        .AddIdentityCookies();
       

        builder.Services.AddHttpClient("NetGameProjectBlazor.Client", client =>
        {
            client.BaseAddress = new Uri("http://localhost:5294/");
        });
        builder.Services.AddScoped(sp =>
        {
            // Get the named client and return it as the default HttpClient
            var factory = sp.GetRequiredService<IHttpClientFactory>();
            return factory.CreateClient("NetGameProjectBlazor.Client");
        });


        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        // builder.Services.AddSwaggerGen();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();


        builder.Services.AddDbContext<GardaNetGameContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        // Add all of our Services and Repositories here!!

        builder.Services.AddScoped<IPhysicalProductService, PhysicalProductsService>();
        builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
        builder.Services.AddScoped<IGamesService, GamesService>();
        builder.Services.AddScoped<IPegiService, PegiService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IReviewService, ReviewService>();
        builder.Services.AddScoped<IGenreService, GenreService>();

        builder.Services.AddScoped<IPhysicalProductRepository, PhysicalProductRepository>();
        builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
        builder.Services.AddScoped<IShoppingCartItemRepository, ShoppingCartItemRepository>();
        builder.Services.AddScoped<IGamesRepository, GamesRepository>();
        builder.Services.AddScoped<IPegiRepository, PegiRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
        builder.Services.AddScoped<IGenreRepository, GenreRepository>();

        builder.Services.AddScoped<IAccountManagement, CookieAuthenticationStateProvider>();

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddRazorPages();


        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
            app.UseMigrationsEndPoint();

            // To activate Swagger
            // app.UseSwagger();
            // app.UseSwaggerUI();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        /*app.UseCors("AllowFrontend");*/

        app.UseHttpsRedirection();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseAntiforgery();

        app.UseStaticFiles();


        app.MapControllers();

        app.MapRazorComponents<App>()
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

        // Add additional endpoints required by the Identity /Account Razor components.
        app.MapAdditionalIdentityEndpoints();


        app.MapRazorPages();

        app.Run();
    }
}
