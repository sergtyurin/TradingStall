using MediatR;

namespace TradingStall.Catalog.Application.Products.Commands;

public class CreateProductCommand : IRequest<long>
{
    public long SellerId { get; init; }
    public string Name { get; init; }
    public long BrandId { get; init; }
    public long CategoryId { get; init; }
    public int AvailableStock { get; init; }
}