namespace TradingStall.Orders.Domain.Model;

public class OrderItem
{
    public long Id { get; set; }
    public long ProductId { get; init; }
    public string ProductName { get; init; }
    public decimal UnitPrice { get; init; }
    public int Quantity { get; private set; }
    
    public OrderItem(long productId, string productName, decimal unitPrice, int quantity = 1)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("Units must be greater than zero");
        }
        
        ProductId = productId;

        ProductName = productName;
        UnitPrice = unitPrice;
        Quantity = quantity;
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