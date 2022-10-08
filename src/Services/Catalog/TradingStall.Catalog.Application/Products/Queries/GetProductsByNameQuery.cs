using MediatR;

namespace TradingStall.Catalog.Application.Products.Queries;

public class GetProductsByNameQuery : IStreamRequest<ProductViewModel>
{
    public string Name { get; set; }
}