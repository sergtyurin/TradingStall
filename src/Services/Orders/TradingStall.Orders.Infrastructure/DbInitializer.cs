using TradingStall.Orders.Domain.Model;

namespace TradingStall.Orders.Infrastructure;

public class DbInitializer
{
    public static void Initialize(OrderContext context)
    {
        if (context.Database.EnsureCreated())
        {
            context.OrderStatuses.AddRange(OrderStatus.List());
            context.SaveChanges();
        }
    }
}