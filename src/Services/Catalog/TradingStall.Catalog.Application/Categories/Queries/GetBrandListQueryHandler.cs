using System.Runtime.CompilerServices;
using MediatR;
using TradingStall.Catalog.Domain.Contracts;

namespace TradingStall.Catalog.Application.Categories.Queries;

public class GetCategoryListQueryHandler : IStreamRequestHandler<GetCategoryListQuery, CategoryViewModel>
{
    private readonly ICategoryRepository _categoryRepository;
    
    public GetCategoryListQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async IAsyncEnumerable<CategoryViewModel> Handle(GetCategoryListQuery request, [EnumeratorCancellation]CancellationToken cancellationToken)
    {
        await foreach (var brand in _categoryRepository.GetAllAsync(cancellationToken))
        {
            yield return new CategoryViewModel
            {
                id = brand.Id,
                name = brand.Name,
            };
        }
    }
}