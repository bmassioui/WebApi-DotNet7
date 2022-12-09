using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[Produces("application/json")]
public class CatalogController : ApiBaseController
{
    public CatalogController(IProductService productService) : base(productService)
    { }

    /// <summary>
    /// Get Proucts asynchronously
    /// </summary>
    /// <returns>List of Product sorted by creation date DESC</returns>
    /// <response code="200">Returns the list of Product sorted by creation date DESC</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
        return Ok(await _productService.GetProductsAsync());
    }

    /// <summary>
    /// Get Product by Id asynchronously
    /// </summary>
    /// <param name="productId">Product's Id</param>
    /// <returns>Product's details</returns>
    /// <response code="200">Returns the Product's details</response>
    /// <response code="404">If no Product found</response>
    [HttpGet("{productId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Product>> Get(Guid productId)
    {
        return Ok(await _productService.GetByIdAsync(productId));
    }

    /// <summary>
    /// Add Product to catalog asynchronously
    /// </summary>
    /// <param name="product"></param>
    /// <returns>The created Product</returns>
    /// <response code="201">The created Product's details</response>
    /// <response code="400">Unable to create Product</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Product>> Add(Product product)
    {
        await _productService.AddAsync(product);

        return CreatedAtAction(nameof(Get), new { product.Id }, product);
    }

    /// <summary>
    /// Update Product in Catalog asynchronously
    /// </summary>
    /// <returns></returns>
    /// <response code="204">The update done successfully</response>
    /// <response code="404">If no Product found</response>
    /// <response code="400">Unable to update Product</response>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Put(Guid productId)
    {
        return NoContent();
    }

    /// <summary>
    /// Delete Product from Catalog by Id asynchronously
    /// </summary>
    /// <param name="productId">Product's Id</param>
    /// <returns></returns>
    /// <response code="204">The deletion done successfully</response>
    /// <response code="404">If no Product found</response>
    /// <response code="400">Unable to delete Product</response>
    [HttpDelete("{productId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Delete(Guid productId)
    {
        return NoContent();
    }
}