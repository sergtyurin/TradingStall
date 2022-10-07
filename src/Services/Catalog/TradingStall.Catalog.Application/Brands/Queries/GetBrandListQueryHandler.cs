using System.Runtime.CompilerServices;
using MediatR;
using TradingStall.Catalog.Domain.Contracts;

namespace TradingStall.Catalog.Application.Brands.Queries;

public class GetBrandListQueryHandler : IStreamRequestHandler<GetBrandListQuery, BrandViewModel>
{
    private readonly IBrandRepository _brandRepository;

    public GetBrandListQueryHandler(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async IAsyncEnumerable<BrandViewModel> Handle(GetBrandListQuery request, [EnumeratorCancellation]CancellationToken cancellationToken)
    {
        await foreach (var brand in _brandRepository.GetAllAsync(cancellationToken))
        {
            yield return new BrandViewModel
            {
                id = brand.Id,
                name = brand.Name,
            };
        }
    }
}