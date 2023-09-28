using System;
using System.Collections.Generic;

namespace Players.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Dept { get; set; }

    public string? Gender { get; set; }

    public string? Country { get; set; }

    public double? Salary { get; set; }
}
