using Homework1.Application.Exceptions;
using Homework1.Application.Interfaces;
using Homework1.Application.Models;

namespace Homework1.Application.Services;

public class ReportService : IReportService
{
    private readonly IOrderRepository _repository;

    public ReportService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public ClientReport GetReport(long clientId)
    {
        IEnumerable<Order> clientOrders = _repository.GetByClientId(clientId);

        if (!clientOrders.Any())
        {
            throw new ClientNotFoundException($"'Client with id {clientId} not found");
        }

        float totalPrice = clientOrders.Sum(order => order.ItemPrice * order.ItemQuantity);

        string favouriteItem = GetFavouriteItemName(clientOrders);

        return new ClientReport
        {
            ClientId = clientId,
            FavouriteItemName = favouriteItem,
            OrdersSum = totalPrice
        };

    }

    private static string GetFavouriteItemName(IEnumerable<Order> clientOrders)
    {
        Dictionary<string, int> counterDict = new();

        foreach (var order in clientOrders)
        {
            if (!counterDict.ContainsKey(order.ItemName))
            {
                counterDict[order.ItemName] = 0;
            }
            
            counterDict[order.ItemName] += order.ItemQuantity;
        }
        
        var favouriteItem = counterDict
            .MaxBy(pair => pair.Value)
            .Key;

        return favouriteItem;
    }
    
}
