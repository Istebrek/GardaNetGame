using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetGameProjectBlazor.Shared.DTOs;

public class ShoppingCartItemCreateDto
{
    public int ProductId { get; set; } 
    public int Quantity { get; set; }
    public decimal PriceAtPurchase { get; set; }
}
