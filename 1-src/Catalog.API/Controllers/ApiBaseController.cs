using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiBaseController : ControllerBase
{
    protected readonly CatalogDbContext _catalogDbContext;

    public ApiBaseController(CatalogDbContext catalogDbContext)
    {
        _catalogDbContext = catalogDbContext ?? throw new ArgumentNullException(nameof(catalogDbContext), "Unable to resolve Catalog Db Context");
    }
}
