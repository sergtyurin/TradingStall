using Microsoft.EntityFrameworkCore;
using TradingStall.Warehouse.Domain.Model;
using TradingStall.Warehouse.Infrastructure.EntityTypeConfigurations;

namespace TradingStall.Warehouse.Infrastructure;

public class WarehouseContext : DbContext
{
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Apply entities configurations
        builder.ApplyConfiguration(new BrandConfiguration());
        
        base.OnModelCreating(builder);
    }
}