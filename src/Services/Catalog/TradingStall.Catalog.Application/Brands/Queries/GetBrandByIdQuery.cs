using MediatR;
using TradingStall.Catalog.Domain.Model;

namespace TradingStall.Catalog.Application.Brands.Queries;

public class GetBrandByIdQuery : IRequest<BrandDetailsViewModel?>
{
    public long Id { get; init; }
}