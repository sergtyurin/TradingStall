using MediatR;

namespace TradingStall.Warehouse.Application.Products.Commands;

public class CreateProductCommand : IRequest<long>
{
    public long SellerId { get; set; }
    public string Name { get; set; }
    public long BrandId { get; set; }
    public long CategoryId { get; set; }
    public int AvailableStock { get; set; }
    
    public CreateProductCommand(long sellerId, string name, long brandId, long categoryId, int availableStock)
    {
        SellerId = sellerId;
        Name = name;
        BrandId = brandId;
        CategoryId = categoryId;
        AvailableStock = availableStock;
    }

}