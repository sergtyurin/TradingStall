using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TradingStall.Catalog.Application.Brands.Commands;
using TradingStall.Catalog.Application.Brands.Queries;
using TradingStall.Catalog.Application.Categories.Commands;
using TradingStall.Catalog.Application.Categories.Queries;

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
        
        return CreatedAtAction("BrandById", new{ id = brandId }, null);
    }

    // GET api/v1/[controller]/catalogbrands/{id}
    [HttpGet]
    [Route("catalogbrands/{id:long}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(BrandDetailsViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<BrandDetailsViewModel>> BrandByIdAsync(long id)
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
    
    // GET api/v1/[controller]/catalogbrands
    [HttpGet]
    [Route("catalogbrands")]
    [ProducesResponseType(typeof(IAsyncEnumerable<BrandViewModel>), (int)HttpStatusCode.OK)]
    public IAsyncEnumerable<BrandViewModel> CatalogBrandsAsync()
    {
        return _mediator.CreateStream(new GetBrandListQuery());
    }
    
    
    //POST api/v1/[controller]/catalogcategory
    [Route("catalogcategory")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> CreateCategoryAsync([FromBody] CreateCategoryCommand createCategoryCommand)
    {
        var brandId = await _mediator.Send(createCategoryCommand);
        
        return CreatedAtAction("CategoryById", new{ id = brandId }, null);
    }

    // GET api/v1/[controller]/catalogcategory/{id}
    [HttpGet]
    [Route("catalogcategory/{id:long}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(CategoryDetailsViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CategoryDetailsViewModel>> CategoryByIdAsync(long id)
    {
        if (id <= 0)
            return BadRequest();
        
        var categoryVM = await _mediator.Send(new GetCategoryByIdQuery
        {
            Id = id,
        });

        if (categoryVM is not null)
            return categoryVM;

        return NotFound();
    }
    
    // GET api/v1/[controller]/catalogcategory
    [HttpGet]
    [Route("catalogcategory")]
    [ProducesResponseType(typeof(IAsyncEnumerable<CategoryViewModel>), (int)HttpStatusCode.OK)]
    public IAsyncEnumerable<CategoryViewModel> CatalogCategoriesAsync()
    {
        return _mediator.CreateStream(new GetCategoryListQuery());
    }
}

