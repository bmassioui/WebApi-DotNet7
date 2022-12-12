using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Catalog.API.Controllers;

[Produces("application/json")]
public class CatalogController : ApiBaseController
{
    public CatalogController(IProductService productService) : base(productService) { }

    /// <summary>
    /// Get products asynchronously
    /// </summary>
    /// <param name="includeDeleted">True: to include soft deleted products, otherwise FALSE</param>
    /// <returns>List of product sorted by creation date DESC</returns>
    /// <response code="200">Returns the list of product sorted by creation date DESC</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ReadProduct>>> Get(bool includeDeleted)
    {
        Expression<Func<Product, bool>>? filter = (!includeDeleted ? product => !product.IsDeleted : null);

        var products = await _productService.GetProductsAsync(filter, orderBy);

        return Ok(products);

        static IOrderedQueryable<Product> orderBy(IQueryable<Product> products)
        {
            return products.OrderByDescending(product => product.CreatedAt);
        }
    }

    /// <summary>
    /// Get product by ID asynchronously
    /// </summary>
    /// <param name="productId">Product's ID</param>
    /// <returns>Product's details</returns>
    /// <response code="200">Returns the product's details</response>
    /// <response code="404">If no product could be found</response>
    [HttpGet("{productId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReadProduct>> Get(Guid productId)
    {
        var product = await _productService.GetByIdAsync(productId);

        return
            product is not null ?
            Ok(product) :
            NotFound($"No Product with the given ID:'{productId}' could be found.");
    }

    /// <summary>
    /// Add product asynchronously
    /// </summary>
    /// <param name="product">Product to add</param>
    /// <returns>Product's details</returns>
    /// <response code="201">Product's details</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<ReadProduct>> Add(AddProduct product)
    {
        var addedProduct = await _productService.AddAsync(product);

        return CreatedAtAction(nameof(Get), new { addedProduct.Id }, addedProduct);
    }

    /// <summary>
    /// Update product asynchronously
    /// </summary>
    /// <returns></returns>
    /// <response code="204">The update done successfully</response>
    /// <response code="404">If no product could be found</response>
    /// <response code="400">Unable to update product</response>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(Guid productId, UpdateProduct product)
    {
        // PUT request requires the client to send the entire updated entity, not just the changes. To support partial updates, use HTTP PATCH.
        if (productId != product.Id) return BadRequest($"Payload invalid, please make sure that, productId:'{productId}' is equal to product.id:'{product.Id}'.");

        if (!await _productService.UpdateAsync(product)) return NotFound($"No Product with the given ID:'{productId}' could be found.");

        return NoContent();
    }

    /// <summary>
    /// Delete product by ID asynchronously
    /// </summary>
    /// <param name="productId">Product's ID</param>
    /// <returns></returns>
    /// <response code="204">The deletion done successfully</response>
    /// <response code="404">If no product could be found</response>
    [HttpDelete("{productId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid productId)
    {
        var productToDelete = await _productService.GetByIdAsync(productId);

        if (productToDelete is null) return NotFound($"No Product with the given ID:'{productId}' could be found.");

        await _productService.MarkAsDeletedAsync(productId);

        return NoContent();
    }
} 