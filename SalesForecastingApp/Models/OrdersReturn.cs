using System;
using System.Collections.Generic;

namespace SalesForecastingApp.Models;

public partial class OrdersReturn
{
    public string OrderId { get; set; } = null!;

    public string? Comments { get; set; }
}
