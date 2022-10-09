namespace TradingStall.Orders.Domain.Model;

public class OrderItem
{
    public long Id { get; set; }
    public long ProductId { get; init; }
    public string ProductName { get; init; }
    public decimal UnitPrice { get; init; }
    public long Quantity { get; private set; }
    
    public OrderItem(int productId, string productName, decimal unitPrice, int units = 1)
    {
        if (units <= 0)
        {
            throw new ArgumentException("Units must be greater than zero");
        }
        
        ProductId = productId;

        ProductName = productName;
        UnitPrice = unitPrice;
        Quantity = units;
    }
    
    public void AddUnits(int units)
    {
        if (units < 0)
        {
            throw new ArgumentException("Units must be greater than or equal to zero");
        }

        Quantity += units;
    }
}