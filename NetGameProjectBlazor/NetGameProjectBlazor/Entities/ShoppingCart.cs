using NetGameProjectBlazor.Data;
using System;
using System.Collections.Generic;

namespace NetGameProjectBlazor.Entities;

public partial class ShoppingCart
{
    public int Id { get; set; }

    public string CustomerId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ApplicationUser Customer { get; set; } = null!;

    public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
}
