using System;
using System.Collections.Generic;

namespace Debt_Management.Models;

public partial class Admin
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public double? Available { get; set; }

    public double? Debt { get; set; }
}
