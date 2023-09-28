using System;
using System.Collections.Generic;

namespace Players.Models;

public partial class Player
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string Country { get; set; } = null!;

    public int? HighestScore { get; set; }
}
