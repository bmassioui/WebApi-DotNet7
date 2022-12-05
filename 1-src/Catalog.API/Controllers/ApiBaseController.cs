using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApiBaseController : ControllerBase
{
    public ApiBaseController()
    {

    }
}
