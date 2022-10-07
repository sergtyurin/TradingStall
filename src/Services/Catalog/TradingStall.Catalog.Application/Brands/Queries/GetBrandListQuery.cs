using MediatR;

namespace TradingStall.Catalog.Application.Brands.Queries;

public class GetBrandListQuery : IStreamRequest<BrandViewModel> { }