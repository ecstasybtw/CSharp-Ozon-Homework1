using Homework1.Application.Interfaces;
using Homework1.Application.Services;
using Homework1.Infrastructure.Repositories;
using Homework1.Presentation;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton<IOrderRepository, CsvOrderRepository>();
services.AddSingleton<IReportService, ReportService>();
services.AddSingleton<ClientIdParser>();
services.AddSingleton<ConsoleApplication>();

using var serviceProvider = services.BuildServiceProvider();
var application = serviceProvider.GetRequiredService<ConsoleApplication>();
application.Run();
