namespace TradingStall.Warehouse.Domain.Contracts;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}