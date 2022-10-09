using Microsoft.Extensions.DependencyInjection;
using TradingStall.Orders.Application.NotificationHandler;

namespace TradingStall.Orders.MessageBroker;

public static class DependencyInjection
{
    public static IServiceCollection AddMessageBroker(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<HttpProducer>();
        services.AddScoped<IMessageBroker, MessageBroker>();

        return services;
    }
}
