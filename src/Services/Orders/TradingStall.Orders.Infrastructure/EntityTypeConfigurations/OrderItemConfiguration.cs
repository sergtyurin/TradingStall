using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradingStall.Orders.Domain.Model;

namespace TradingStall.Orders.Infrastructure.EntityTypeConfigurations
{
    class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");

            builder.HasKey(o => o.Id);

            builder.Property<long>("OrderId").IsRequired();
            builder.Property(e => e.ProductId).IsRequired();
            builder.Property(e => e.ProductName).IsRequired();
            builder.Property(e => e.UnitPrice).IsRequired();
            builder.Property(e => e.Quantity).IsRequired();
        }
    }
}
