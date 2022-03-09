using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
