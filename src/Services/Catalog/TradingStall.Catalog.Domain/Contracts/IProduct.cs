namespace TradingStall.Catalog.Domain.Contracts;

public interface IProduct
{
    int AddStock(int quantity);
    int RemoveStock(int quantity);
}