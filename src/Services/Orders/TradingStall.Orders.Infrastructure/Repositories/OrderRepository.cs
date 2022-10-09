using Microsoft.EntityFrameworkCore;
using TradingStall.Orders.Domain.Contracts;
using TradingStall.Orders.Domain.Model;

namespace TradingStall.Orders.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderContext _context;

    public OrderRepository(OrderContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<Order> AddAsync(Order order, CancellationToken cancellationToken = default(CancellationToken)) 
        => (await _context.Orders.AddAsync(order, cancellationToken)).Entity;

    public async Task<Order?> GetByIdAsync(long orderId, CancellationToken cancellationToken = default(CancellationToken)) 
        => await _context.Orders.SingleOrDefaultAsync(e => e.Id == orderId, cancellationToken);

    public IAsyncEnumerable<Order> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken)) 
        => _context.Orders.AsAsyncEnumerable();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken)) 
        => await _context.SaveChangesAsync(cancellationToken);
}