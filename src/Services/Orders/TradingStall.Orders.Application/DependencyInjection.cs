using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TradingStall.Orders.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped<IOrderingInfrastructure, OrderingInfrastructure>();
        return services;
    }
}