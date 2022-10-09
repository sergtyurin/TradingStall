using Microsoft.Extensions.DependencyInjection;
using TradingStall.Orders.Application.NotificationHandler;

namespace TradingStall.Orders.MessageBroker;

public class MessageBroker : IMessageBroker
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public MessageBroker(IServiceScopeFactory serviceScopeFactory)
        => _serviceScopeFactory = serviceScopeFactory;
    
    public async Task Publish(IntegrationEvent integrationEvent, CancellationToken cancellationToken)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var scopedServices = scope.ServiceProvider;
        var producer = scopedServices.GetRequiredService<HttpProducer>();

        await producer.Publish(integrationEvent, cancellationToken);
    }
}
