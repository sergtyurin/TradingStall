using MediatR;
using TradingStall.Catalog.Domain.Contracts;

namespace TradingStall.Catalog.Application.Categories.Queries;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDetailsViewModel?>
{
    private readonly ICategoryRepository _categoryRepository;
    
    public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryDetailsViewModel?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var brand = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);
        
        return brand is null ? null : new CategoryDetailsViewModel
        {
            id = brand.Id,
            name = brand.Name,
        };
    }
}