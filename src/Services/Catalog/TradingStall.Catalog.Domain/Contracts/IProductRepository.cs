using TradingStall.Catalog.Domain.Model;

namespace TradingStall.Catalog.Domain.Contracts;

public interface IProductRepository : IRepository<Product>
{
    Product Add(Product product);
    void Update(Product product);
    Task<Product> GetAsync(int productId);
}