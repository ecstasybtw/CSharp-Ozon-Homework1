using Homework1.Application.Models;

namespace Homework1.Application.Interfaces;


public interface IReportWriter
{
    void Write(IEnumerable<ClientReport> clientReports);
}
