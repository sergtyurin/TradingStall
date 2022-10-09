using MediatR;
using TradingStall.Orders.Domain.Model;

namespace TradingStall.Orders.Domain.DomainEvents;

public class BaseOrderDomainEvent : INotification
{
    public OrderStatus OrderStatus { get; }
    public long OrderId { get; }
    
    protected BaseOrderDomainEvent(OrderStatus orderStatus, long orderId)
    {
        OrderStatus = orderStatus;
        OrderId = orderId;
    }
}