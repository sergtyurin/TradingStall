using System;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TradingStall.Catalog.Application.Brands.Commands;
using TradingStall.Catalog.Application.Brands.Queries;

namespace TradingStall.Catalog.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CatalogController : ControllerBase
{
    
    private readonly IMediator _mediator;
    private readonly ILogger<CatalogController> _logger;

    public CatalogController(IMediator mediator, ILogger<CatalogController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    
    //POST api/v1/[controller]/catalogbrands
    [Route("catalogbrands")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> CreateBrandAsync([FromBody] CreateBrandCommand createBrandCommand)
    {
        var brandId = await _mediator.Send(createBrandCommand);
        
        return CreatedAtAction("ItemById", new{ id = brandId }, null);
    }

    // GET api/v1/[controller]/catalogbrands/{id}
    [HttpGet]
    [Route("catalogbrands/{id:long}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(BrandViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<BrandViewModel>> ItemByIdAsync(long id)
    {
        if (id <= 0)
            return BadRequest();
        
        var brandVM = await _mediator.Send(new GetBrandByIdQuery
        {
            Id = id,
        });

        if (brandVM is not null)
            return brandVM;

        return NotFound();
    }
    
}

