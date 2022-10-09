namespace TradingStall.Orders.Domain.Contracts;

public interface IRepository<T>
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}