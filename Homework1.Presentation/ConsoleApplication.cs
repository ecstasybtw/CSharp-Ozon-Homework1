using Homework1.Application.Exceptions;
using Homework1.Application.Interfaces;
using Homework1.Application.Models;

namespace Homework1.Presentation;

public class ConsoleApplication
{
    private readonly IReportService _reportService;
    private readonly ClientIdParser _parser;
    private readonly IReportWriter _reportWriter;

    public ConsoleApplication(
        IReportService reportService,
        ClientIdParser parser,
        IReportWriter reportWriter)
    {
        _reportService = reportService;
        _parser = parser;
        _reportWriter = reportWriter;
    }

    public void Run()
    {
        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            return;
        }

        var reports = new List<ClientReport>();

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

                reports.Add(report);
            }
            catch (ClientNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        if (reports.Count > 0)
        {
            _reportWriter.Write(reports);
        }
    }
}
