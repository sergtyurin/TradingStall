namespace TradingStall.Warehouse.Infrastructure;

public class DbInitializer
{
    public static void Initialize(WarehouseContext context)
    {
        context.Database.EnsureCreated();
    }
}