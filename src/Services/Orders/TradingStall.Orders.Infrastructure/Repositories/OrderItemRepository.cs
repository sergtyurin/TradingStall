using Microsoft.EntityFrameworkCore;
using TradingStall.Orders.Domain.Contracts;
using TradingStall.Orders.Domain.Model;

namespace TradingStall.Orders.Infrastructure.Repositories;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly OrderContext _context;

    public OrderItemRepository(OrderContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<OrderItem> AddAsync(OrderItem orderItem, CancellationToken cancellationToken = default(CancellationToken)) 
        => (await _context.OrderItems.AddAsync(orderItem, cancellationToken)).Entity;

    public async Task AddRangeAsync(IEnumerable<OrderItem> orderItems, CancellationToken cancellationToken = default) 
        => await _context.OrderItems.AddRangeAsync(orderItems, cancellationToken);

    public async Task<OrderItem?> GetByIdAsync(long orderItemId, CancellationToken cancellationToken = default(CancellationToken)) 
        => await _context.OrderItems.SingleOrDefaultAsync(e => e.Id == orderItemId, cancellationToken);

    public IAsyncEnumerable<OrderItem> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken)) 
        => _context.OrderItems.AsAsyncEnumerable();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken)) 
        => await _context.SaveChangesAsync(cancellationToken);
}