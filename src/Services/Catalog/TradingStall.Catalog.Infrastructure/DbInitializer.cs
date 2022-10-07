namespace TradingStall.Catalog.Infrastructure;

public class DbInitializer
{
    public static void Initialize(WarehouseContext context)
    {
        context.Database.EnsureCreated();
    }
}