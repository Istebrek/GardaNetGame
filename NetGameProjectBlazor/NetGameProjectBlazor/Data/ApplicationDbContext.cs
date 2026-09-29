using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetGameProjectBlazor.Client.Pages;
using NetGameProjectBlazor.Entities;
using ShoppingCart = NetGameProjectBlazor.Entities.ShoppingCart;

namespace NetGameProjectBlazor.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}

	public DbSet<ApplicationUser> applicationUsers { get; set; }
	

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		    builder.Ignore<Order>();
			builder.Ignore<OrderItem>();
			builder.Ignore<Review>();
			builder.Ignore<ShoppingCart>();
			builder.Ignore<ShoppingCartItem>();
			builder.Ignore<Product>();
			builder.Ignore<Entities.Game>();
			builder.Ignore<Genre>();
			builder.Ignore<Pegi>();

		builder.Entity<IdentityUser>(entity =>
		{
			entity.Property(u => u.UserName).HasMaxLength(85);
			entity.Property(u => u.NormalizedUserName).HasMaxLength(85);
			entity.Property(u => u.Email).HasMaxLength(85);
			entity.Property(u => u.NormalizedEmail).HasMaxLength(85);
		});

	}
}