using MediatR;
using TradingStall.Catalog.Domain.Contracts;
using TradingStall.Catalog.Domain.Model;

namespace TradingStall.Catalog.Application.Brands.Commands;

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, long>
{
    private readonly IBrandRepository _brandRepository;

    public CreateBrandCommandHandler(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
    }

    public async Task<long> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = new Brand
        {
            Name = request.Name,
        };

        await _brandRepository.AddAsync(brand, cancellationToken);
        await _brandRepository.SaveChangesAsync(cancellationToken);

        return brand.Id;
    }
}