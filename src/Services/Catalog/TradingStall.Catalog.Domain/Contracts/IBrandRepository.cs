using TradingStall.Catalog.Domain.Model;

namespace TradingStall.Catalog.Domain.Contracts;

public interface IBrandRepository : IRepository<Brand>
{
    Task<Brand> AddAsync(Brand brand, CancellationToken cancellationToken = default(CancellationToken));
    Task<Brand?> GetByIdAsync(long brandId, CancellationToken cancellationToken = default(CancellationToken));
}