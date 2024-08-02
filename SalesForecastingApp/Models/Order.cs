using System;
using System.Collections.Generic;

namespace SalesForecastingApp.Models;

public partial class Order
{
    public string OrderId { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public DateTime ShipDate { get; set; }

    public string? ShipMode { get; set; }

    public string? CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string Segment { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string? PostalCode { get; set; }

    public string Region { get; set; } = null!;
}
