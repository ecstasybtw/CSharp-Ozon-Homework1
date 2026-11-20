using Homework1.Application.Exceptions;
using Homework1.Application.Interfaces;

namespace Homework1.Presentation;

public class ConsoleApplication
{
    private readonly IReportService _reportService;
    private readonly ClientIdParser _parser;

    public ConsoleApplication(IReportService reportService, ClientIdParser parser)
    {
        _reportService = reportService;
        _parser = parser;
    }

    public void Run()
    {
        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            return;
        }

        foreach (var result in _parser.Parse(input))
        {
            if (result.ClientId is not long clientId)
            {
                Console.WriteLine($"Invalid client id: {result.Input}");
                continue;
            }

            try
            {
                var report = _reportService.GetReport(clientId);

                Console.WriteLine(
                    $"client_id: {report.ClientId}, orders_sum: {report.OrdersSum:F2}, favourite_item_name: {report.FavouriteItemName}"
                );
            }
            catch (ClientNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
