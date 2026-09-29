using Homework1.Application.Exceptions;
using Homework1.Application.Interfaces;
using Homework1.Application.Services;
using Homework1.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection();

string csvPath = "orders_log.csv";

services.AddSingleton<IOrderRepository>(
    _ => new CsvOrderRepository(csvPath)
);

services.AddSingleton<IReportService, ReportService>();

var serviceProvider = services.BuildServiceProvider();

var reportService =
    serviceProvider.GetRequiredService<IReportService>();

    
string? input = Console.ReadLine();

if (string.IsNullOrWhiteSpace(input))
{
    return;
}

string[] clientIds = input.Split(
    ' ',
    StringSplitOptions.RemoveEmptyEntries
);


foreach (var clientIdString in clientIds)
{
    if (!long.TryParse(clientIdString, out long clientId))
    {
        Console.WriteLine($"Invalid client id: {clientIdString}");
        continue;
    }

    try
    {
        var report = reportService.GetReport(clientId);

        Console.WriteLine(
            $"client_id: {report.ClientId}, orders_sum: {report.OrdersSum:F2}, favourite_item_name: {report.FavouriteItemName}"
        );
    }
    catch (ClientNotFoundException exception)
    {
        Console.WriteLine(exception.Message);
    }
}    