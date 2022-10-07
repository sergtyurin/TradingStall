using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradingStall.Catalog.Domain.Model;

namespace TradingStall.Catalog.Infrastructure.EntityTypeConfigurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands");
        
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.Id).IsUnique();

        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
    }
}