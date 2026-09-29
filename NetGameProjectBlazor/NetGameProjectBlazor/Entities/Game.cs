using System;
using System.Collections.Generic;

namespace NetGameProjectBlazor.Entities;

public partial class Game
{
    public int Id { get; set; }

    public int? PegiId { get; set; }

    public int? ProductId { get; set; }

    public virtual Pegi? Pegi { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
}
