using System;
using System.Collections.Generic;

namespace Debt_Management.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Dob { get; set; }

    public double? Available { get; set; }

    public double? Debt { get; set; }
}
