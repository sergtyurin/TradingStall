using MediatR;
using TradingStall.Orders.Domain.Contracts;
using TradingStall.Orders.Domain.DomainEvents;
using TradingStall.Orders.Domain.Lifecycles;
using TradingStall.Orders.Domain.Model;

namespace TradingStall.Orders.Application;

public class OrderingInfrastructure : IOrderingInfrastructure
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMediator _mediator;

    public OrderingInfrastructure(IOrderRepository orderRepository, IMediator mediator)
    {
        _orderRepository = orderRepository;
        _mediator = mediator;
    }

    public async Task CreateOrder(Order order, CancellationToken cancellationToken = default(CancellationToken))
    {
        await _orderRepository.AddAsync(order, cancellationToken);
        await _orderRepository.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(
            new OrderCreatedEvent(
                order.Id, 
                new OrderCreatedData(order.BuyerId, order.Id, order.OrderItems)), 
            cancellationToken);
    }
}