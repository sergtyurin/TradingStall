using TradingStall.Catalog.Domain.Model;

namespace TradingStall.Catalog.Domain.Contracts;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category> AddAsync(Category сategory, CancellationToken cancellationToken = default(CancellationToken));
    Task<Category?> GetByIdAsync(long сategoryId, CancellationToken cancellationToken = default(CancellationToken));
    IAsyncEnumerable<Category> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
}