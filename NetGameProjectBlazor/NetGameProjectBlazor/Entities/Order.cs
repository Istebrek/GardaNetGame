using NetGameProjectBlazor.Data;
using System;
using System.Collections.Generic;

namespace NetGameProjectBlazor.Entities;

public partial class Order
{
    public int Id { get; set; }

    public string? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual ApplicationUser Customer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
