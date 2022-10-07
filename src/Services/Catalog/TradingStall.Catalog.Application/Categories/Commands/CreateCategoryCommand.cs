using MediatR;

namespace TradingStall.Catalog.Application.Categories.Commands;

public class CreateCategoryCommand : IRequest<long>
{
    public string Name { get; init; }
    
    public CreateCategoryCommand(string name)
    {
        Name = name;
    }
}