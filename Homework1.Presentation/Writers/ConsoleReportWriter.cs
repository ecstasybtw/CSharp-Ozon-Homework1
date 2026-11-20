using Homework1.Application.Interfaces;
using Homework1.Application.Models;

namespace Homework1.Presentation.Writers;


public class ConsoleReportWriter : IReportWriter
{
    public void Write(IEnumerable<ClientReport> clientReports)
    {
        foreach (var clientReport in clientReports)
        {
            Console.WriteLine(
                $"client_id: {clientReport.ClientId}, orders_sum: {clientReport.OrdersSum:F2}, favourite_item_name: {clientReport.FavouriteItemName}"
            );
        }
    }
}
