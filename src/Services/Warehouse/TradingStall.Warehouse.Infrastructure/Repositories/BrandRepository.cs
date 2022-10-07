using Microsoft.EntityFrameworkCore;
using TradingStall.Warehouse.Domain.Contracts;
using TradingStall.Warehouse.Domain.Model;

namespace TradingStall.Warehouse.Infrastructure.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly WarehouseContext _context;

    public BrandRepository(WarehouseContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<Brand> AddAsync(Brand brand, CancellationToken cancellationToken = default(CancellationToken)) 
        => (await _context.Brands.AddAsync(brand, cancellationToken)).Entity;

    public async Task<Brand?> GetByIdAsync(long brandId, CancellationToken cancellationToken = default(CancellationToken)) 
        => await _context.Brands.SingleOrDefaultAsync(e => e.Id == brandId, cancellationToken);
    
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken)) 
        => await _context.SaveChangesAsync(cancellationToken);
}