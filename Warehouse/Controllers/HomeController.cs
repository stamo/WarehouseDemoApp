using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Diagnostics;
using Warehouse.Core.Constants;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> logger;

        private readonly IDistributedCache cache;

        public HomeController(
            ILogger<HomeController> _logger,
            IDistributedCache _cache)
        {
            logger = _logger;
            cache = _cache;
        }

        public async Task<IActionResult> Index()
        {

            DateTime dateTime = DateTime.Now;
            var cachedData = await cache.GetStringAsync("cachedTime");

            if (cachedData == null)
            {
                cachedData = dateTime.ToString();
                DistributedCacheEntryOptions cacheOptions = new DistributedCacheEntryOptions()
                {
                    SlidingExpiration = TimeSpan.FromSeconds(20),
                    AbsoluteExpiration = DateTime.Now.AddSeconds(60)
                };

                await cache.SetStringAsync("cachedTime", cachedData, cacheOptions);
            }

            return View(nameof(Index), cachedData);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}