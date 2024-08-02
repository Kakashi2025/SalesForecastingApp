using System;
using System.Collections.Generic;

namespace SalesForecastingApp.Models;

public partial class Product
{
    public string OrderId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public string? Category { get; set; }

    public string? SubCategory { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Sales { get; set; }

    public int Quantity { get; set; }

    public decimal? Discount { get; set; }

    public decimal? Profit { get; set; }
}
