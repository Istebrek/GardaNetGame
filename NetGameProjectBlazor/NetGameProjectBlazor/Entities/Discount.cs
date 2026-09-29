using System;
using System.Collections.Generic;

namespace NetGameProjectBlazor.Entities;

public partial class Discount
{
    public int Id { get; set; }

    public int Discount1 { get; set; }

    public string Code { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}
