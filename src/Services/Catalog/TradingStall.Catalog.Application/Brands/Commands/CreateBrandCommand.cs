using MediatR;

namespace TradingStall.Catalog.Application.Brands.Commands;

public class CreateBrandCommand : IRequest<long>
{
    public string Name { get; init; }
    
    public CreateBrandCommand(string name)
    {
        Name = name;
    }
}