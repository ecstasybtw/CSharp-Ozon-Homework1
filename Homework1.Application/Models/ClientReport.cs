namespace Homework1.Application.Models;

public record ClientReport(
    long ClientId,
    float OrdersSum,
    string FavouriteItemName
);
