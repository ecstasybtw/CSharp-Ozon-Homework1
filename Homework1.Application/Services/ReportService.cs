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
        var clientOrders = _repository.GetByClientId(clientId);

        if (!clientOrders.Any())
        {
            throw new ClientNotFoundException($"'Client with id {clientId} not found");
        }

        float totalPrice = clientOrders.Sum(order => order.ItemPrice * order.ItemQuantity);

        string favouriteItem = GetFavouriteItemName(clientOrders);

        return new ClientReport(
            ClientId: clientId,
            OrdersSum: totalPrice,
            FavouriteItemName: favouriteItem
        );

    }

    private static string GetFavouriteItemName(IEnumerable<Order> clientOrders)
    {
        Dictionary<string, int> quantityByItemName = new();

        foreach (var order in clientOrders)
        {
            if (!quantityByItemName.ContainsKey(order.ItemName))
            {
                quantityByItemName[order.ItemName] = 0;
            }
            
            quantityByItemName[order.ItemName] += order.ItemQuantity;
        }
        
        var favouriteItem = quantityByItemName
            .MaxBy(pair => pair.Value)
            .Key;

        return favouriteItem;
    }
    
}
