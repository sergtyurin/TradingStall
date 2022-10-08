namespace TradingStall.Catalog.Application.Products.Queries;

public record ProductDetailsViewModel
{
    public long id { get; set; }
    public long seller_id { get; init; }
    public string name { get; init; }
    public string brand_name { get; init; }
    public string category_name { get; init; }
    public int available_stock { get; init; }
}