using TradingStall.Orders.Domain.Model;

namespace TradingStall.Orders.Domain.Contracts;

public interface IOrderItemRepository : IRepository<OrderItem>
{
    Task<OrderItem> AddAsync(OrderItem orderItem, CancellationToken cancellationToken = default(CancellationToken));
    Task AddRangeAsync(IEnumerable<OrderItem> orderItems, CancellationToken cancellationToken = default(CancellationToken));
    Task<OrderItem?> GetByIdAsync(long orderItemId, CancellationToken cancellationToken = default(CancellationToken));
    IAsyncEnumerable<OrderItem> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
}