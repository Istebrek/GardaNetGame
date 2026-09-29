using System;
using System.Collections.Generic;

namespace NetGameProjectBlazor.Entities;

public partial class Pegi
{
    public int Id { get; set; }

    public string Age { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
