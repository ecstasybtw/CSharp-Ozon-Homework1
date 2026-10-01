using Homework1.Application.Interfaces;
using Homework1.Application.Models;
using System.Globalization;

namespace Homework1.Infrastructure.Repositories;

public class CsvOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();
    private readonly string _csvPath;

    public CsvOrderRepository()
    {
        _csvPath = Path.Combine(
            AppContext.BaseDirectory,
            "orders_log.csv"
        );
        ParseCsv();
    }

    private void ParseCsv()
    {
        foreach (var line in File.ReadLines(_csvPath).Skip(1))
        {
            string[] values = line.Split(',');
            _orders.Add(
                new Order
                {
                    ClientId = long.Parse(values[0]),
                    OrderId = long.Parse(values[1]),
                    ItemName = values[2],
                    ItemQuantity = int.Parse(values[3]),
                    ItemPrice = float.Parse(
                        values[4],
                        CultureInfo.InvariantCulture
                    )
                }
            );
        }
    }

    public IEnumerable<Order> GetByClientId(long clientId)
    {
        List<Order> ordersToReturn = new List<Order>();

        foreach (var order in _orders)
        {
            if (order.ClientId == clientId)
            {
                ordersToReturn.Add(order);
            }
        }

        return ordersToReturn;
    }
}
