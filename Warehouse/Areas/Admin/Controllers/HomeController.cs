using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
