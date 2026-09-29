using NetGameProjectBlazor.Data;
using System;
using System.Collections.Generic;

namespace NetGameProjectBlazor.Entities;

public partial class Review
{
    public int Id { get; set; }

    public int Rating { get; set; }

    public string? ReviewText { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CustomerId { get; set; }

    public int? ProductId { get; set; }

    public virtual ApplicationUser? Customer { get; set; }

    public virtual Product? Product { get; set; }
}
