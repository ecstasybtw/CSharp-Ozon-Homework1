using Homework1.Application.Models;

namespace Homework1.Application.Interfaces;

public interface IReportService
{
    public ClientReport GetReport(long clientId);
}
