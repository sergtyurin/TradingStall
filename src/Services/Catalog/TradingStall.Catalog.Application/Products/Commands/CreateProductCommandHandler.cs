using MediatR;
using TradingStall.Catalog.Domain.Contracts;
using TradingStall.Catalog.Domain.Model;

namespace TradingStall.Catalog.Application.Products.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
{
    private readonly IProductRepository _productRepository;
    
    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product()
        {
            SellerId = request.SellerId,
            Name = request.Name,
            BrandId = request.BrandId,
            CategoryId = request.CategoryId,
        };
        product.AddStock(request.AvailableStock);

        await _productRepository.AddAsync(product, cancellationToken);
        await _productRepository.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}