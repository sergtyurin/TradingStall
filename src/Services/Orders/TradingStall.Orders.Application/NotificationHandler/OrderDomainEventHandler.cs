using MediatR;
using TradingStall.Orders.Domain.DomainEvents;

namespace TradingStall.Orders.Application.NotificationHandler;

internal class OrderDomainEventHandler : INotificationHandler<OrderCreatedEvent>
{
    private readonly IMessageBroker _messageBroker;

    public OrderDomainEventHandler(IMessageBroker messageBroker)
        => _messageBroker = messageBroker;

    public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        => _messageBroker.Publish(
            new IntegrationEvent(notification.OrderId, notification.OrderStatus, notification.Event),
            cancellationToken);
}
