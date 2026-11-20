using System.IO;
using Homework1.Application.Interfaces;
using Homework1.Application.Models;

namespace Homework1.Presentation.Writers;

public class FileReportWriter : IReportWriter
{
    public void Write(IEnumerable<ClientReport> clientReports)
    {
        var fileName = $"report_{Guid.NewGuid()}.txt";
        var reportLines = new List<string>();

        foreach (var clientReport in clientReports)
        {
            reportLines.Add(
                $"client_id: {clientReport.ClientId}, orders_sum: {clientReport.OrdersSum:F2}, favourite_item_name: {clientReport.FavouriteItemName}"
            );
        }

        File.WriteAllLines(fileName, reportLines);
    }
}
