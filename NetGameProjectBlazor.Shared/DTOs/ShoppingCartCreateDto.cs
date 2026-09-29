using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetGameProjectBlazor.Shared.DTOs;

public class ShoppingCartCreateDto
{
    public string? CustomerId { get; set; } // 0 för gäster
    public DateTime? CreatedAt { get; set; }

    public List<ShoppingCartItemDto> ShoppingCartItems = new List<ShoppingCartItemDto>();
}
