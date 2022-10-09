using Microsoft.EntityFrameworkCore;
using TradingStall.Orders.Domain.Model;
using TradingStall.Orders.Infrastructure.EntityTypeConfigurations;

namespace TradingStall.Orders.Infrastructure;

public class OrderContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }

    public OrderContext(DbContextOptions<OrderContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Apply entities configurations
        builder.ApplyConfiguration(new OrderConfiguration());
        builder.ApplyConfiguration(new OrderItemConfiguration());
        builder.ApplyConfiguration(new OrderStatusConfiguration());
        
        base.OnModelCreating(builder);
    }
}