using TradingStall.Warehouse.Domain.Model;

namespace TradingStall.Warehouse.Domain.Contracts;

public interface ICategoryRepository : IRepository<Category>
{
    Category Add(Category category);
    void Update(Category category);
    Task<Category> GetAsync(int categoryId);
}