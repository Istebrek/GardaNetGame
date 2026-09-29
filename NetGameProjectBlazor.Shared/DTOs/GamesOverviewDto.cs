using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetGameProjectBlazor.Shared.DTOs;

public class GamesOverviewDto
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string? ProductImageUrl { get; set; }
    
}
