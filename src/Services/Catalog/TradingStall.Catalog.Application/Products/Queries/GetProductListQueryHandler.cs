using System.Runtime.CompilerServices;
using MediatR;
using TradingStall.Catalog.Domain.Contracts;

namespace TradingStall.Catalog.Application.Products.Queries;

public class GetProductListQueryHandler : IStreamRequestHandler<GetProductListQuery, ProductViewModel>
{
    private readonly IProductRepository _productRepository;

    public GetProductListQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async IAsyncEnumerable<ProductViewModel> Handle(GetProductListQuery request, [EnumeratorCancellation]CancellationToken cancellationToken)
    {
        await foreach (var product in _productRepository.GetAllFullAsync(cancellationToken))
        {
            yield return new ProductViewModel
            {
                id = product.Id,
                name = product.Name,
                brand_name = product.Brand.Name,
                seller_id = product.SellerId,
            };
        }
    }
}