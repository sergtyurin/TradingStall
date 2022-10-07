using MediatR;

namespace TradingStall.Catalog.Application.Categories.Queries;

public class GetCategoryByIdQuery : IRequest<CategoryDetailsViewModel?>
{
    public long Id { get; init; }
}