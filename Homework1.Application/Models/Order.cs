namespace Homework1.Application.Models;

public class Order
{
    public long ClientId { get; set; }
    public long OrderId { get; set; }
    public string ItemName { get; set; }
    public int ItemQuantity { get; set; }
    public float ItemPrice { get; set; }
}