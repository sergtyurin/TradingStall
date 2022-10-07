using TradingStall.Catalog.Domain.Model;

namespace TradingStall.Catalog.Domain.Contracts;

public interface ICategoryRepository : IRepository<Category>
{
    Category Add(Category category);
    void Update(Category category);
    Task<Category> GetAsync(int categoryId);
}