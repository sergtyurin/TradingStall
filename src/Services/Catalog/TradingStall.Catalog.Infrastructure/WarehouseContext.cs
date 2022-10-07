using Microsoft.EntityFrameworkCore;
using TradingStall.Catalog.Domain.Model;
using TradingStall.Catalog.Infrastructure.EntityTypeConfigurations;

namespace TradingStall.Catalog.Infrastructure;

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