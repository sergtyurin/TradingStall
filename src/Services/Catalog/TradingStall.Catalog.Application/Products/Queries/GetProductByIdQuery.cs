using MediatR;

namespace TradingStall.Catalog.Application.Products.Queries;

public class GetProductByIdQuery : IRequest<ProductDetailsViewModel?>
{
    public long Id { get; init; }
}