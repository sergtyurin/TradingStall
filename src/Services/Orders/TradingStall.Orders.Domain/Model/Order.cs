namespace TradingStall.Orders.Domain.Model;

public class Order
{
    public long Id { get; set; }
    public long BuyerId { get; init; }
    public string? Address { get; private set; }
    public bool DeliveryRequested { get; private set; }
    public long OrderStatusId { get; private set; }
    public OrderStatus OrderStatus { get; private set; }
    private readonly List<OrderItem> _orderItems;
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
    public DateTime OrderDate { get; init; }
    public decimal Total() => _orderItems.Sum(e => e.Quantity * e.UnitPrice);

    public Order(long buyerId)
    {
        BuyerId = buyerId;
        OrderStatusId = OrderStatus.Created.Id;
        OrderDate = DateTime.UtcNow;
        _orderItems = new List<OrderItem>();
    }
    
    public void AddOrderItem(long productId, string productName, decimal unitPrice, int units = 1)
    {
        var existingOrderItem = _orderItems.SingleOrDefault(o => o.ProductId == productId);

        if (existingOrderItem != null)
        {
            existingOrderItem.AddUnits(units);
        }
        else
        {
            var orderItem = new OrderItem(productId, productName, unitPrice, units);
            _orderItems.Add(orderItem);
        }
    }
    
    public void SetAwaitingValidationStatus()
    {
        if (OrderStatusId == OrderStatus.Created.Id)
        {
            //TODO: Send notification of awaiting validation status
            OrderStatusId = OrderStatus.AwaitingValidation.Id;
        }
    }
    
    public void SetStockConfirmedStatus()
    {
        if (OrderStatusId == OrderStatus.AwaitingValidation.Id)
        {
            //TODO: Send notification of stock confirmation status
            OrderStatusId = OrderStatus.StockConfirmed.Id;
        }
    }
    
    public void SetShippedStatus()
    {
        if (OrderStatusId != OrderStatus.StockConfirmed.Id || !DeliveryRequested)
        {
            StatusChangeException(OrderStatus.Shipped);
        }

        OrderStatusId = OrderStatus.Shipped.Id;
        //TODO: Send notification of shipped status
    }
    
    public void SetDeliveredStatus()
    {
        if (OrderStatusId != OrderStatus.Shipped.Id)
        {
            StatusChangeException(OrderStatus.Delivered);
        }

        OrderStatusId = OrderStatus.Delivered.Id;
        //TODO: Send notification of delivered status
    }
    
    public void SetReceiptConfirmedStatus()
    {
        if (OrderStatusId < OrderStatus.StockConfirmed.Id)
        {
            StatusChangeException(OrderStatus.ReceiptConfirmed);
        }

        OrderStatusId = OrderStatus.ReceiptConfirmed.Id;
        //TODO: Send notification of receipt confirmation
    }
    
    public void SetCancelledStatus()
    {
        if (OrderStatusId > OrderStatus.Shipped.Id)
        {
            StatusChangeException(OrderStatus.Cancelled);
        }

        OrderStatusId = OrderStatus.Cancelled.Id;
        //TODO: Send notification of order cancellation
    }
    
    public void SetDeliveryFailedStatus()
    {
        if (OrderStatusId != OrderStatus.Shipped.Id)
        {
            StatusChangeException(OrderStatus.DeliveryFailed);
        }

        OrderStatusId = OrderStatus.DeliveryFailed.Id;
        //TODO: Send notification of delivery failure
    }
    
    private void StatusChangeException(OrderStatus orderStatusToChange)
    {
        throw new InvalidOperationException($"Is not possible to change the order status from {OrderStatus.Name} to {orderStatusToChange.Name}.");
    }
}