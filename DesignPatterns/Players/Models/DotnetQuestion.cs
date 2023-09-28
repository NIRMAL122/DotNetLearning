using System;
using System.Collections.Generic;

namespace Players.Models;

public partial class DotnetQuestion
{
    public int Id { get; set; }

    public DateTime? PriceDate { get; set; }

    public DateTime? DelivDate { get; set; }

    public int? Price { get; set; }
}
