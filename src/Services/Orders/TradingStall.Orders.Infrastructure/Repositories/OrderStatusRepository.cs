using Microsoft.EntityFrameworkCore;
using TradingStall.Orders.Domain.Contracts;
using TradingStall.Orders.Domain.Model;

namespace TradingStall.Orders.Infrastructure.Repositories;

public class OrderStatusRepository : IOrderStatusRepository
{
    private readonly OrderContext _context;

    public OrderStatusRepository(OrderContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<OrderStatus?> GetByIdAsync(long orderStatusId, CancellationToken cancellationToken = default(CancellationToken)) 
        => await _context.OrderStatuses.SingleOrDefaultAsync(e => e.Id == orderStatusId, cancellationToken);
}