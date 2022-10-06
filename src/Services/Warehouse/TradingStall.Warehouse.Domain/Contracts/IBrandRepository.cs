using TradingStall.Warehouse.Domain.Model;

namespace TradingStall.Warehouse.Domain.Contracts;

public interface IBrandRepository : IRepository<Brand>
{
    Brand Add(Brand brand);
    void Update(Brand brand);
    Task<Brand> GetAsync(int brandId);
}