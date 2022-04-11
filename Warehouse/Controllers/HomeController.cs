using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Diagnostics;
using Warehouse.Core.Constants;
using Warehouse.Core.Contracts;
using Warehouse.Infrastructure.Data;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> logger;

        private readonly IDistributedCache cache;

        private readonly IFileService fileService;

        public HomeController(
            ILogger<HomeController> _logger,
            IDistributedCache _cache,
            IFileService _fileService)
        {
            logger = _logger;
            cache = _cache;
            fileService = _fileService;
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

        [HttpGet]
        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);

                        var fileToSave = new ApplicationFile()
                        {
                            FileName = file.FileName,
                            Content = stream.ToArray()
                        };

                        await fileService.SaveFileAsync(fileToSave);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "HomeController/UploadFile");

                TempData[MessageConstant.ErrorMessage] = "Възникна проблем по време на запис";
            }

            TempData[MessageConstant.SuccessMessage] = "Файла е качен успешно";

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SetCultureCookie(string cltr, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cltr)),
                new CookieOptions 
                {
                    Expires = DateTime.UtcNow.AddYears(1),
                    SameSite = SameSiteMode.Strict
                });

            return LocalRedirect(returnUrl);
        }

        public IActionResult GetData()
        {
            return Json(new 
            { 
                name = "Stamo", 
                age = 44, 
                gender = "male",  
                nationality = "Bulgarian"
            });
        }
    }
}