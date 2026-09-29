using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetGameProjectBlazor.Shared.DTOs;

public class ShoppingCartItemUpdateDto
{
    public int Id { get; set; } // Hitta specifik artikelrad(cartitem) i kundkorgen
    public int Quantity { get; set; }
}
