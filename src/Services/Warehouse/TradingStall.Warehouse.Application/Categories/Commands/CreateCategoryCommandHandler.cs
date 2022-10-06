using MediatR;
using TradingStall.Warehouse.Domain.Contracts;
using TradingStall.Warehouse.Domain.Model;

namespace TradingStall.Warehouse.Application.Categories.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, long>
{
    private readonly ICategoryRepository _categoryRepository;
    
    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    public async Task<long> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Name = request.Name,
        };

        _categoryRepository.Add(category);
        
        return await _categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}