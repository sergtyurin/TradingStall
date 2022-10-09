using MediatR;

namespace TradingStall.Orders.Application.Orders.Queries;

public class GetOrderByIdQuery : IRequest<OrderDetailsViewModel?>
{
    public long Id { get; init; }
}