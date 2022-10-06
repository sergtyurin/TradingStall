using MediatR;
using TradingStall.Warehouse.Domain.Contracts;
using TradingStall.Warehouse.Domain.Model;

namespace TradingStall.Warehouse.Application.Brands.Commands;

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

        _brandRepository.Add(brand);
        
        return await _brandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}