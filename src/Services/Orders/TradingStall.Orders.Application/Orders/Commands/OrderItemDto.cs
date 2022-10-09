namespace TradingStall.Orders.Application.Orders.Commands;

public record struct OrderItemDto
{
    public long ProductId { get; init; }
    public string ProductName { get; init; }
    public decimal UnitPrice { get; init; }
    public int Quantity { get; init; }
}