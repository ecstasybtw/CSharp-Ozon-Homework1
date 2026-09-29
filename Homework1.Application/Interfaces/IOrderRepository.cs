using Homework1.Application.Models;

namespace Homework1.Application.Interfaces;

public interface IOrderRepository
{
    IEnumerable<Order> GetByClientId(long clientID);
}