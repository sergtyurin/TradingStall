using TradingStall.Warehouse.Domain.Model;

namespace TradingStall.Warehouse.Domain.Contracts;

public interface IProductRepository : IRepository<Product>
{
    Product Add(Product product);
    void Update(Product product);
    Task<Product> GetAsync(int productId);
}