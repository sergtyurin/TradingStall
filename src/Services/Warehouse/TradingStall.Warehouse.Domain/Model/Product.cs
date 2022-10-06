using TradingStall.Warehouse.Domain.Contracts;

namespace TradingStall.Warehouse.Domain.Model;

public class Product : IProduct
{
    public long Id { get; set; }
    public long SellerId { get; set; }
    public string Name { get; set; }
    public long BrandId { get; set; }
    public Brand Brand { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public int AvailableStock { get; private set; }

    public int AddStock(int quantity) => AvailableStock += quantity;

    public int RemoveStock(int quantity)
    {
        if (AvailableStock < quantity)
            throw new Exception($"Insufficient quantity of {Name} in stock");

        return AvailableStock -= quantity;
    }
}