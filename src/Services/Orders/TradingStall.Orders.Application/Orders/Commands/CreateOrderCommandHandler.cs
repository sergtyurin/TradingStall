using MediatR;
using TradingStall.Orders.Domain.Model;

namespace TradingStall.Orders.Application.Orders.Commands;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, long>
{
    private readonly IOrderingInfrastructure _orderingInfrastructure;

    public CreateOrderCommandHandler(IOrderingInfrastructure orderingInfrastructure)
    {
        _orderingInfrastructure = orderingInfrastructure;
    }

    public async Task<long> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order(request.BuyerId);

        foreach (var orderItem in request.OrderItems)
        {
            order.AddOrderItem(orderItem.ProductId, orderItem.ProductName, orderItem.UnitPrice, orderItem.Quantity);
        }

        await _orderingInfrastructure.CreateOrder(order, cancellationToken);
        
        return order.Id;
    }
}