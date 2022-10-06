namespace TradingStall.Warehouse.Domain.Contracts;

public interface IRepository<T>
{
    IUnitOfWork UnitOfWork { get; }
}