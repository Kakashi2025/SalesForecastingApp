using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalesForecastingApp.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesForecastingApp.Helper; 
using SalesForecastingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesForecastingApp.Pages.Sales
{
    public class IndexModel : PageModel
    {
        private readonly SalesForeCastingDbContext _context;

        public IndexModel(SalesForeCastingDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int Year { get; set; }

        [BindProperty]
        public decimal GlobalIncrementPercentage { get; set; }

        [BindProperty]
        public Dictionary<string, decimal> StateIncrements { get; set; } = new Dictionary<string, decimal>();

        public SalesViewModel? SalesData { get; set; }
        public List<string>? States { get; set; }

        public void OnGet()
        {
            States = _context.Orders.Select(o => o.State).Distinct().ToList() ?? new List<string>();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Handle invalid model state
                return Page();
            }

            SalesData = await GetSalesDataAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostDownloadCsvAsync()
        {
            var forecastData = await GetForecastDataAsync();

            var csvData = CsvHelper.GenerateCsv(forecastData);
            var fileName = $"SalesForecast_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            return File(csvData, "text/csv", fileName);
        }

        private async Task<SalesViewModel> GetSalesDataAsync()
        {
            // Implement logic to get sales data based on the selected year and increments
            var salesData = new SalesViewModel
            {
                TotalSales = await CalculateTotalSalesAsync(),
                IncrementedTotalSales = await CalculateIncrementedTotalSalesAsync(),
                StateSalesBreakdown = await CalculateStateSalesBreakdownAsync()
            };

            return salesData;
        }

        private async Task<decimal> CalculateTotalSalesAsync()
        {
            // Implement your logic to calculate total sales
            var totalSales = 0m;

            var orders = await _context.Orders
                .Where(o => o.OrderDate.Year == Year)
                .ToListAsync();

            var products = await _context.Products.ToListAsync();

            totalSales = orders
                .Join(products,
                    order => order.OrderId,
                    product => product.OrderId,
                    (order, product) => product.Sales - (orders.Count(r => r.OrderId == order.OrderId) * product.Sales))
                .Sum();

            return totalSales;
        }

        private async Task<decimal> CalculateIncrementedTotalSalesAsync()
        {
            var totalSales = await CalculateTotalSalesAsync();
            var incrementedTotalSales = totalSales + (totalSales * (GlobalIncrementPercentage / 100));
            return incrementedTotalSales;
        }

        private async Task<List<StateSale>> CalculateStateSalesBreakdownAsync()
        {
            var stateSales = new List<StateSale>();

            var orders = await _context.Orders
                .Where(o => o.OrderDate.Year == Year)
                .ToListAsync();

            var products = await _context.Products.ToListAsync();

            stateSales = orders
                .Join(products,
                    order => order.OrderId,
                    product => product.OrderId,
                    (order, product) => new
                    {
                        order.State,
                        Sales = product.Sales - (orders.Count(r => r.OrderId == order.OrderId) * product.Sales)
                    })
            .GroupBy(x => x.State)
                .Select(group => new StateSale
                {
                    State = group.Key,
                    Sales = group.Sum(x => x.Sales)
                })
                .ToList();

            return stateSales;
        }

        private async Task<IEnumerable<StateForecast>> GetForecastDataAsync()
        {
            var salesData = await GetSalesDataAsync();

            var forecastData = salesData.StateSalesBreakdown
                .Select(stateSales => new StateForecast
                {
                    State = stateSales.State,
                    PercentageIncrease = StateIncrements.GetValueOrDefault(stateSales.State, GlobalIncrementPercentage),
                    SalesValue = stateSales.Sales + (stateSales.Sales * (StateIncrements.GetValueOrDefault(stateSales.State, GlobalIncrementPercentage) / 100))
                });

            return forecastData;
        }
    }
}