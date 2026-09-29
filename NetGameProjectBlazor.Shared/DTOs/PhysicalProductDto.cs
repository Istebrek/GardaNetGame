using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetGameProjectBlazor.Shared.DTOs;

public class PhysicalProductDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public string? ProductImageUrl { get; set; }

    public bool? IsActive { get; set; }
    public int StockQuantity { get; set; }

}
