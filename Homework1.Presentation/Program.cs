using Homework1.Application.Interfaces;
using Homework1.Application.Services;
using Homework1.Infrastructure.Repositories;
using Homework1.Presentation;
using Homework1.Presentation.Writers;
using Microsoft.Extensions.DependencyInjection;

if (args.Length == 0 || (args[0] != "console" && args[0] != "file"))
{
    Console.WriteLine("Specify report mode as the first argument: console or file.");
    Environment.ExitCode = 1;
    return;
}

var services = new ServiceCollection();

if (args[0] == "console")
{
    services.AddSingleton<IReportWriter, ConsoleReportWriter>();
}
else
{
    services.AddSingleton<IReportWriter, FileReportWriter>();
}

services.AddSingleton<IOrderRepository, CsvOrderRepository>();
services.AddSingleton<IReportService, ReportService>();
services.AddSingleton<ClientIdParser>();
services.AddSingleton<ConsoleApplication>();

using var serviceProvider = services.BuildServiceProvider();
var application = serviceProvider.GetRequiredService<ConsoleApplication>();
application.Run();
