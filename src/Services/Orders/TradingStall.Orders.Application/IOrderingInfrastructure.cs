using TradingStall.Orders.Domain.Model;

namespace TradingStall.Orders.Application;

public interface IOrderingInfrastructure
{
    public Task CreateOrder(Order order, CancellationToken cancellationToken = default(CancellationToken));
}