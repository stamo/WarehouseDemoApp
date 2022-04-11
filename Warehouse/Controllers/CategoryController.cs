using Microsoft.AspNetCore.Mvc;
using Warehouse.Core.Contracts;

namespace Warehouse.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> Index(int p = 1, int s = 10)
        {
            var model = await service.GetCategories(p, s);

            return View(model);
        }
    }
}
