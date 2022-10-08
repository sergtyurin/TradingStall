using MediatR;

namespace TradingStall.Catalog.Application.Products.Queries;

public class GetProductListQuery : IStreamRequest<ProductViewModel> { }