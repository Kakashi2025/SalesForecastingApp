using System.Collections.Generic;

namespace SalesForecastingApp.ViewModel
{
    public class SalesViewModel
    {
        public decimal TotalSales { get; set; }
        public decimal IncrementedTotalSales { get; set; }

        public List<StateSale>? StateSalesBreakdown { get; set; }

    }

    
}
