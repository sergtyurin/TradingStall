using MediatR;
using TradingStall.Warehouse.Domain.Model;

namespace TradingStall.Warehouse.Application.Brands.Queries;

public class GetBrandByIdQuery : IRequest<BrandViewModel?>
{
    public long Id { get; init; }
}