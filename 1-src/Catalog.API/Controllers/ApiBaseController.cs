using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    public class ApiBaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
