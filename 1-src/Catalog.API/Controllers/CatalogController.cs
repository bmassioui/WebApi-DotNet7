using Catalog.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[Produces("application/json")]
public class CatalogController : ApiBaseController
{
    public CatalogController(IProductService productService) : base(productService)
    { }

    /// <summary>
    /// Get proucts asynchronously
    /// </summary>
    /// <returns>List of product sorted by creation date DESC</returns>
    /// <response code="200">Returns the list of product sorted by creation date DESC</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
        var products = await _productService.GetProductsAsync(orderBy: products => products.OrderByDescending(product => product.CreatedAt));

        return Ok(products);
    }

    /// <summary>
    /// Get Product by ID asynchronously
    /// </summary>
    /// <param name="productId">Product's ID</param>
    /// <returns>Product's details</returns>
    /// <response code="200">Returns the product's details</response>
    /// <response code="404">If no product found</response>
    [HttpGet("{productId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Product>> Get(Guid productId)
    {
        var product = await _productService.GetByIdAsync(productId);

        return
            product is not null ?
            Ok(product) :
            NotFound($"No Product with the given (ID:{productId}) could be found.");
    }

    /// <summary>
    /// Add product to catalog asynchronously
    /// </summary>
    /// <param name="product">Product to add</param>
    /// <returns>Product's details</returns>
    /// <response code="201">Product's details</response>
    /// <response code="400">Unable to add product</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Product>> Add(Product product)
    {
        await _productService.AddAsync(product);

        return CreatedAtAction(nameof(Get), new { product.Id }, product);
    }

    /// <summary>
    /// Update product asynchronously
    /// </summary>
    /// <returns></returns>
    /// <response code="204">The update done successfully</response>
    /// <response code="404">If no product found</response>
    /// <response code="400">Unable to update product</response>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Put(Guid productId, UpdateProduct product)
    {
        return NoContent();
    }

    /// <summary>
    /// Delete product by ID asynchronously
    /// </summary>
    /// <param name="productId">Product's ID</param>
    /// <returns></returns>
    /// <response code="204">The deletion done successfully</response>
    /// <response code="404">If no product found</response>
    /// <response code="400">Unable to delete product</response>
    [HttpDelete("{productId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Delete(Guid productId)
    {
        return NoContent();
    }
}