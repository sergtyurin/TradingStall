using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TradingStall.Warehouse.Domain.Contracts;
using TradingStall.Warehouse.Infrastructure.Repositories;

namespace TradingStall.Warehouse.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        
        services.AddDbContext<WarehouseContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

        services.AddScoped<IBrandRepository, BrandRepository>();
        
        return services;
    }
}