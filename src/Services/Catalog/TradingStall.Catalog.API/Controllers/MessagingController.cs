using System.Net;
using System.Threading;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TradingStall.Catalog.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class MessagingController : Controller
{
    private readonly IMediator _mediator;

    public MessagingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //POST api/v1/[controller]
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public ActionResult ProcessMessageAsync([FromQuery] string @event, CancellationToken cancellationToken)
    {
        return Ok(@event);
    }

}