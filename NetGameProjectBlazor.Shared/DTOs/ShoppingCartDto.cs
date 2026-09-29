using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetGameProjectBlazor.Shared.DTOs;

public class ShoppingCartDto
{
    public int Id { get; set; }
    public string CustomerId { get; set; } 
    public DateTime? CreatedAt { get; set; }

    public List<ShoppingCartItemDto> ShoppingCartItems { get; set; } = new List<ShoppingCartItemDto>();
    public decimal TotalPrice => ShoppingCartItems.Sum(c => c.Subtotal);
}
