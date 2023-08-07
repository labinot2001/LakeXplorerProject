using LakeXplorerProject.Data.Services;
using LakeXplorerProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LakeXplorerProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILakeServices _service;
        public HomeController(ILogger<HomeController> logger, ILakeServices service)
        {
            _logger = logger;
            _service = service;

        }

        public async Task<IActionResult>  Index()
        {
            var allLakes = await _service.GetAllAsync();
            return View(allLakes);
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