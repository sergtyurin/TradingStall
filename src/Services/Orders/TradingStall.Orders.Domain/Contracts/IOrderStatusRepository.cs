using TradingStall.Orders.Domain.Model;

namespace TradingStall.Orders.Domain.Contracts;

public interface IOrderStatusRepository
{
    Task<OrderStatus?> GetByIdAsync(long orderStatusId, CancellationToken cancellationToken = default(CancellationToken));
}