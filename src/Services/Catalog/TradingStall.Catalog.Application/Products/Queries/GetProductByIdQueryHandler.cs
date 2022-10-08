using MediatR;
using TradingStall.Catalog.Application.Categories.Queries;
using TradingStall.Catalog.Domain.Contracts;

namespace TradingStall.Catalog.Application.Products.Queries;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDetailsViewModel?>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDetailsViewModel?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetFullByIdAsync(request.Id, cancellationToken);
        
        return product is null ? null : new ProductDetailsViewModel
        {
            id = product.Id,
            name = product.Name,
            seller_id = product.SellerId,
            brand_name = product.Brand.Name,
            category_name = product.Category.Name,
            available_stock = product.AvailableStock,
        };
    }
}