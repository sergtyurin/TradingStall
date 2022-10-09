using TradingStall.Orders.Domain.Lifecycles;
using TradingStall.Orders.Domain.Model;

namespace TradingStall.Orders.Domain.DomainEvents;

public class OrderCreatedEvent : BaseOrderDomainEvent
{
    public OrderCreatedData Event { get; }
    
    public OrderCreatedEvent(long orderId, OrderCreatedData @event)
        : base(OrderStatus.Created, orderId) => Event = @event;
}
