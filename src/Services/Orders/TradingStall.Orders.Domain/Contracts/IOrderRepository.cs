using TradingStall.Orders.Domain.Model;

namespace TradingStall.Orders.Domain.Contracts;

public interface IOrderRepository : IRepository<Order>
{
    Task<Order> AddAsync(Order order, CancellationToken cancellationToken = default(CancellationToken));
    Task<Order?> GetByIdAsync(long orderId, CancellationToken cancellationToken = default(CancellationToken));
    IAsyncEnumerable<Order> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
}