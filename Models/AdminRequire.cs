using System;
using System.Collections.Generic;

namespace Debt_Management.Models;

public partial class AdminRequire
{
    public int RequireId { get; set; }

    public string? SupplierName { get; set; }

    public string? ProductName { get; set; }

    public double? Weight { get; set; }

    public double? Cost { get; set; }

    public string? Date { get; set; }

    public string? Status { get; set; }
}
