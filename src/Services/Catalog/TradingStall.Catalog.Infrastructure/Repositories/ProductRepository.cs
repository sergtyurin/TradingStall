using Microsoft.EntityFrameworkCore;
using TradingStall.Catalog.Domain.Contracts;
using TradingStall.Catalog.Domain.Model;

namespace TradingStall.Catalog.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly WarehouseContext _context;

    public ProductRepository(WarehouseContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default(CancellationToken)) 
        => (await _context.Products.AddAsync(product, cancellationToken)).Entity;

    public async Task<Product?> GetFullByIdAsync(long productId, CancellationToken cancellationToken = default(CancellationToken)) 
        => await _context.Products
            .Include(e => e.Brand)
            .Include(e => e.Category)
            .SingleOrDefaultAsync(e => e.Id == productId, cancellationToken);

    public IAsyncEnumerable<Product> GetFullByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken)) 
        => _context.Products.Where(e => e.Name.StartsWith(name))
            .Include(e => e.Brand)
            .Include(e => e.Category)
            .AsAsyncEnumerable();

    public IAsyncEnumerable<Product> GetAllFullAsync(CancellationToken cancellationToken = default(CancellationToken)) 
        => _context.Products
            .Include(e => e.Brand)
            .Include(e => e.Category)
            .AsAsyncEnumerable();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken)) 
        => await _context.SaveChangesAsync(cancellationToken);
}