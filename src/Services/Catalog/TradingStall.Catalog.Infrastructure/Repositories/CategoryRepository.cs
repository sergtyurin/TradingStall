using Microsoft.EntityFrameworkCore;
using TradingStall.Catalog.Domain.Contracts;
using TradingStall.Catalog.Domain.Model;

namespace TradingStall.Catalog.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly WarehouseContext _context;

    public CategoryRepository(WarehouseContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<Category> AddAsync(Category category, CancellationToken cancellationToken = default(CancellationToken)) 
        => (await _context.Categories.AddAsync(category, cancellationToken)).Entity;

    public async Task<Category?> GetByIdAsync(long categoryId, CancellationToken cancellationToken = default(CancellationToken)) 
        => await _context.Categories.SingleOrDefaultAsync(e => e.Id == categoryId, cancellationToken);

    public IAsyncEnumerable<Category> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken)) 
        => _context.Categories.AsAsyncEnumerable();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken)) 
        => await _context.SaveChangesAsync(cancellationToken);
}