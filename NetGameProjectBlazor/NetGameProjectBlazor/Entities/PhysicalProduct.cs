using System;
using System.Collections.Generic;

namespace NetGameProjectBlazor.Entities;

public partial class PhysicalProduct
{
    public int StockQuantity { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
