using Homework1.Application.Models;

namespace Homework1.Application.Interfaces;

public interface IReportService
{
    ClientReport GetReport(long clientId);
}
