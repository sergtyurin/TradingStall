using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradingStall.Orders.Domain.Model;

namespace TradingStall.Orders.Infrastructure.EntityTypeConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.Id).IsUnique();
        
        var navigation = builder.Metadata.FindNavigation(nameof(Order.OrderItems));
        navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        
        builder.HasOne(o => o.OrderStatus).WithMany().HasForeignKey("OrderStatusId");
    }
}