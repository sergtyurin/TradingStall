namespace TradingStall.Catalog.Domain.Contracts;

public interface IRepository<T>
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}