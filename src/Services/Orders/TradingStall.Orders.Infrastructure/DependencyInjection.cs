using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TradingStall.Orders.Domain.Contracts;
using TradingStall.Orders.Infrastructure.Repositories;

namespace TradingStall.Orders.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        
        services.AddDbContext<OrderContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

        services.AddScoped<IOrderRepository, OrderRepository>();
        
        return services;
    }
}