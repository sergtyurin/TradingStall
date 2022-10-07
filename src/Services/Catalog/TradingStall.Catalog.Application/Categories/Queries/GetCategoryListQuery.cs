using MediatR;

namespace TradingStall.Catalog.Application.Categories.Queries;

public class GetCategoryListQuery : IStreamRequest<CategoryViewModel> { }