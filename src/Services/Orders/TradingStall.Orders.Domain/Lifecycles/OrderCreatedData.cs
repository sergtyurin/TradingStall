using TradingStall.Orders.Domain.Model;

namespace TradingStall.Orders.Domain.Lifecycles;

public class OrderCreatedData : ILifecycleData
{
    public long BuyerId { get; }
    public long OrderId { get; }
    public IReadOnlyCollection<OrderItem> OrderItems { get; set; }
    
    public OrderCreatedData(long buyerId, long orderId, IReadOnlyCollection<OrderItem> orderItems)
    {
        BuyerId = buyerId;
        OrderId = orderId;
        OrderItems = orderItems;
    }
}
