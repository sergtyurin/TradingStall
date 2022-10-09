namespace TradingStall.Orders.Domain.Model;

public class OrderStatus
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    
    public static OrderStatus Submitted = new OrderStatus(1, nameof(Submitted).ToLowerInvariant());
    public static OrderStatus AwaitingValidation = new OrderStatus(2, nameof(AwaitingValidation).ToLowerInvariant());
    public static OrderStatus StockConfirmed = new OrderStatus(3, nameof(StockConfirmed).ToLowerInvariant());
    public static OrderStatus Shipped = new OrderStatus(4, nameof(Shipped).ToLowerInvariant());
    public static OrderStatus Delivered = new OrderStatus(5, nameof(Delivered).ToLowerInvariant());
    public static OrderStatus ReceiptConfirmed = new OrderStatus(6, nameof(ReceiptConfirmed).ToLowerInvariant());
    public static OrderStatus Cancelled = new OrderStatus(7, nameof(Cancelled).ToLowerInvariant());
    public static OrderStatus DeliveryFailed = new OrderStatus(8, nameof(DeliveryFailed).ToLowerInvariant());


    public OrderStatus(int id, string name) => (Id, Name) = (id, Name);
}