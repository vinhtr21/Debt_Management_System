using System;
using System.Collections.Generic;

namespace Debt_Management.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public double? Price { get; set; }

    public double? Weight { get; set; }
}
