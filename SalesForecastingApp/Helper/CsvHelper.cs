using System.Globalization;
using System.Text;

namespace SalesForecastingApp.Helper
{
    public class CsvHelper
    {
        public static byte[] GenerateCsv(IEnumerable<StateForecast> forecastData)
        {
            var sb = new StringBuilder();
            sb.AppendLine("State,Percentage Increase,Sales Value");

            foreach (var item in forecastData)
            {
                sb.AppendLine($"{item.State},{item.PercentageIncrease.ToString(CultureInfo.InvariantCulture)},{item.SalesValue.ToString(CultureInfo.InvariantCulture)}");
            }

            return Encoding.UTF8.GetBytes(sb.ToString());
        }
    }

    public class StateForecast
    {
        public string? State { get; set; }
        public decimal PercentageIncrease { get; set; }
        public decimal SalesValue { get; set; }
    }
}
