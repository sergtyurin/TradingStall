using TradingStall.Catalog.Domain.Model;

namespace TradingStall.Catalog.Domain.Contracts;

public interface IProductRepository : IRepository<Product>
{
    Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default(CancellationToken));
    Task<Product?> GetFullByIdAsync(long productId, CancellationToken cancellationToken = default(CancellationToken));
    IAsyncEnumerable<Product> GetFullByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken));
    IAsyncEnumerable<Product> GetAllFullAsync(CancellationToken cancellationToken = default(CancellationToken));
}