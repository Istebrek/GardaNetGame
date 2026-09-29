using Microsoft.AspNetCore.Identity;
using NetGameProjectBlazor.Client.Pages;
using NetGameProjectBlazor.Entities;
using ShoppingCart = NetGameProjectBlazor.Entities.ShoppingCart;

namespace NetGameProjectBlazor.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Address { get; set; }
		public ICollection<ShoppingCart?> ShoppingCarts { get; set; }
        public ICollection<Order?> Orders { get; set; }
        public ICollection<Review?> Reviews { get; set; }
    }

}
