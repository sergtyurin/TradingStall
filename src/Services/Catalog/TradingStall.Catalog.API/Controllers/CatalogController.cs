using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TradingStall.Catalog.Application.Brands.Commands;
using TradingStall.Catalog.Application.Brands.Queries;
using TradingStall.Catalog.Application.Categories.Commands;
using TradingStall.Catalog.Application.Categories.Queries;
using TradingStall.Catalog.Application.Products.Commands;
using TradingStall.Catalog.Application.Products.Queries;

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
    public async Task<ActionResult> CreateBrandAsync([FromBody] CreateBrandCommand createBrandCommand, CancellationToken cancellationToken)
    {
        var brandId = await _mediator.Send(createBrandCommand, cancellationToken);
        
        return CreatedAtAction("BrandById", new{ id = brandId }, null);
    }

    // GET api/v1/[controller]/catalogbrands/{id}
    [HttpGet]
    [Route("catalogbrands/{id:long}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(BrandDetailsViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<BrandDetailsViewModel>> BrandByIdAsync(long id, CancellationToken cancellationToken)
    {
        if (id <= 0)
            return BadRequest();
        
        var brandVm = await _mediator.Send(new GetBrandByIdQuery
        {
            Id = id,
        }, cancellationToken);

        if (brandVm is not null)
            return brandVm;

        return NotFound();
    }
    
    // GET api/v1/[controller]/catalogbrands
    [HttpGet]
    [Route("catalogbrands")]
    [ProducesResponseType(typeof(IAsyncEnumerable<BrandViewModel>), (int)HttpStatusCode.OK)]
    public IAsyncEnumerable<BrandViewModel> CatalogBrandsAsync(CancellationToken cancellationToken)
    {
        return _mediator.CreateStream(new GetBrandListQuery(), cancellationToken);
    }
    
    
    //POST api/v1/[controller]/catalogcategories
    [Route("catalogcategories")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> CreateCategoryAsync([FromBody] CreateCategoryCommand createCategoryCommand, CancellationToken cancellationToken)
    {
        var brandId = await _mediator.Send(createCategoryCommand, cancellationToken);
        
        return CreatedAtAction("CategoryById", new{ id = brandId }, null);
    }

    // GET api/v1/[controller]/catalogcategories/{id}
    [HttpGet]
    [Route("catalogcategories/{id:long}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(CategoryDetailsViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CategoryDetailsViewModel>> CategoryByIdAsync(long id, CancellationToken cancellationToken)
    {
        if (id <= 0)
            return BadRequest();
        
        var categoryVm = await _mediator.Send(new GetCategoryByIdQuery
        {
            Id = id,
        }, cancellationToken);

        if (categoryVm is not null)
            return categoryVm;

        return NotFound();
    }
    
    // GET api/v1/[controller]/catalogcategories
    [HttpGet]
    [Route("catalogcategories")]
    [ProducesResponseType(typeof(IAsyncEnumerable<CategoryViewModel>), (int)HttpStatusCode.OK)]
    public IAsyncEnumerable<CategoryViewModel> CatalogCategoriesAsync(CancellationToken cancellationToken)
    {
        return _mediator.CreateStream(new GetCategoryListQuery(), cancellationToken);
    }
    
    //POST api/v1/[controller]/items
    [Route("items")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> CreateCatalogItemAsync([FromBody] CreateProductCommand createProductCommand, CancellationToken cancellationToken)
    {
        var productId = await _mediator.Send(createProductCommand, cancellationToken);
        
        return CreatedAtAction("CatalogItemById", new{ id = productId }, null);
    }

    // GET api/v1/[controller]/items/{id}
    [HttpGet]
    [Route("items/{id:long}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProductDetailsViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ProductDetailsViewModel>> CatalogItemByIdAsync(long id, CancellationToken cancellationToken)
    {
        if (id <= 0)
            return BadRequest();
        
        var productVm = await _mediator.Send(new GetProductByIdQuery
        {
            Id = id,
        }, cancellationToken);

        if (productVm is not null)
            return productVm;

        return NotFound();
    }
    
    // GET api/v1/[controller]/items
    [HttpGet]
    [Route("items")]
    [ProducesResponseType(typeof(IAsyncEnumerable<ProductViewModel>), (int)HttpStatusCode.OK)]
    public IAsyncEnumerable<ProductViewModel> ListCatalogItemsAsync(CancellationToken cancellationToken)
    {
        return _mediator.CreateStream(new GetProductListQuery(), cancellationToken);
    }
}

