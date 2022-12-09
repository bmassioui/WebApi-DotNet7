using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiBaseController : ControllerBase
{
    protected readonly IProductService _productService;

    public ApiBaseController(IProductService productService)
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService), "Unable to resolve Product Service");
    }
}
