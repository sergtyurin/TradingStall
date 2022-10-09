namespace TradingStall.Orders.Application.NotificationHandler;

public interface IMessageBroker
{
    Task Publish(IntegrationEvent integrationEvent, CancellationToken cancellationToken);
}