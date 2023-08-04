using LakeXplorerProject.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace LakeXplorerProject.Controllers
{
    public class LakeController : Controller
    {

        private readonly ILakeServices _service;

        public LakeController(ILakeServices service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allLakes = await _service.GetAllAsync();

            return View(allLakes);
        }




    }
}
