using TradingStall.Orders.Domain.Lifecycles;
using TradingStall.Orders.Domain.Model;

namespace TradingStall.Orders.Application.NotificationHandler;

public class IntegrationEvent
{
    public long order_id { get; }
    public string order_status { get; }
    public ILifecycleData data { get;}
    
    public IntegrationEvent(long orderId, OrderStatus status, ILifecycleData data)
    {
        order_id = orderId;
        order_status = status.Name;
        this.data = data;
    }
}
