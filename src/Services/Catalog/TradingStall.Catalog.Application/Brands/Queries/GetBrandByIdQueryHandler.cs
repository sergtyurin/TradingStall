using MediatR;
using TradingStall.Catalog.Domain.Contracts;

namespace TradingStall.Catalog.Application.Brands.Queries;

public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, BrandViewModel?>
{
    private readonly IBrandRepository _brandRepository;

    public GetBrandByIdQueryHandler(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<BrandViewModel?> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
    {
        var brand = await _brandRepository.GetByIdAsync(request.Id, cancellationToken);
        
        return brand is null ? null : new BrandViewModel
        {
            id = brand.Id,
            name = brand.Name,
        };
    }
}