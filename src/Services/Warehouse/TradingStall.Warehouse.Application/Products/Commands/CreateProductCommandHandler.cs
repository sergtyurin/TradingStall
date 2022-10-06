using MediatR;
using TradingStall.Warehouse.Domain.Contracts;
using TradingStall.Warehouse.Domain.Model;

namespace TradingStall.Warehouse.Application.Products.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
{
    private readonly IProductRepository _productRepository;
    
    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            SellerId = request.SellerId,
            Name = request.Name,
            BrandId = request.BrandId,
            CategoryId = request.CategoryId,
        };

        _productRepository.Add(product);
        
        return await _productRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}