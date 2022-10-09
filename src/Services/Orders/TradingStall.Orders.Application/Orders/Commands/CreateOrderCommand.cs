using MediatR;

namespace TradingStall.Orders.Application.Orders.Commands;

public class CreateOrderCommand : IRequest<long>
{
    public long BuyerId { get; set; }
    public List<OrderItemDto> OrderItems { get; set; } = new();
}