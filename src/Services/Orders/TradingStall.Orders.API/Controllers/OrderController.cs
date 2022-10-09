using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TradingStall.Orders.Application.Orders.Commands;
using TradingStall.Orders.Application.Orders.Queries;

namespace TradingStall.Orders.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<OrderController> _logger;

    public OrderController(IMediator mediator, ILogger<OrderController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    //POST api/v1/[controller]/orders
    [Route("orders")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> CreateCategoryAsync([FromBody] CreateOrderCommand createOrderCommand, CancellationToken cancellationToken)
    {
        var orderId = await _mediator.Send(createOrderCommand, cancellationToken);
        
        return CreatedAtAction("OrderById", new{ id = orderId }, null);
    }
    
    // GET api/v1/[controller]/orders/{id}
    [HttpGet]
    [Route("orders/{id:long}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(OrderDetailsViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<OrderDetailsViewModel>> OrderByIdAsync(long id, CancellationToken cancellationToken)
    {
        if (id <= 0)
            return BadRequest();
        
        var orderVm = await _mediator.Send(new GetOrderByIdQuery
        {
            Id = id,
        }, cancellationToken);

        if (orderVm is not null)
            return orderVm;

        return NotFound();
    }

}