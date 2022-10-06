namespace TradingStall.Warehouse.Domain;

public interface IProduct
{
    int AddStock(int quantity);
    int RemoveStock(int quantity);
}