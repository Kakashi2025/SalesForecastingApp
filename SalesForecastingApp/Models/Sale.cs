using System;
using System.Collections.Generic;

namespace SalesForecastingApp.Models;

public partial class Sale
{
    public DateTime OrderDate { get; set; }

    public DateTime ShipDate { get; set; }

    public string CustomerId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public decimal? SalesAmount { get; set; }

    public int? Quantity { get; set; }

    public decimal? Discount { get; set; }

    public string? Region { get; set; }

    public string? Category { get; set; }

    public string? Segment { get; set; }

    public string? Scenario { get; set; }
}
