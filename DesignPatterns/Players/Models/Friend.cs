using System;
using System.Collections.Generic;

namespace Players.Models;

public partial class Friend
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Sex { get; set; }

    public string? Designation { get; set; }

    public string? Company { get; set; }

    public string? City { get; set; }
}
