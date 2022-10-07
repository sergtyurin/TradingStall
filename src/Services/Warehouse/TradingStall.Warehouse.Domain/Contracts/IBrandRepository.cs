using TradingStall.Warehouse.Domain.Model;

namespace TradingStall.Warehouse.Domain.Contracts;

public interface IBrandRepository : IRepository<Brand>
{
    Task<Brand> AddAsync(Brand brand, CancellationToken cancellationToken = default(CancellationToken));
    Task<Brand?> GetByIdAsync(long brandId, CancellationToken cancellationToken = default(CancellationToken));
}