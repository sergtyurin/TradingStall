namespace TradingStall.Catalog.Application.Products.Queries;

public record ProductViewModel
{
    public long id { get; set; }
    public long seller_id { get; init; }
    public string name { get; init; }
    public string brand_name { get; init; }
}