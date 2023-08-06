using LakeXplorerProject.Data.Services;
using LakeXplorerProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace LakeXplorerProject.Controllers
{
    public class LakeSightingController : Controller
    {

        private readonly ILakeSightingService _service;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public LakeSightingController(ILakeSightingService service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<IActionResult> Index()
        {
            var allLakes = await _service.GetAllAsync();

            return View(allLakes);
        }

        public async Task<IActionResult> Create()
        {
            var lakeDropdownsData = await _service.GetNewLakeDropdownsValues();
            ViewBag.Lake = new SelectList(lakeDropdownsData.Lakes, "Id", "Name");

            return View();
        }
       

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] LakeSighting lakesighting)
        {
            if (!ModelState.IsValid)
            {
                var lakeDropdownsData = await _service.GetNewLakeDropdownsValues();

                ViewBag.Lake = new SelectList(lakeDropdownsData.Lakes, "Id", "Name");

                return View(lakesighting);
            }

            // If the user has uploaded an image
            if (lakesighting.ImageFile != null && lakesighting.ImageFile.Length > 0)
            {
                using (var image = Image.Load(lakesighting.ImageFile.OpenReadStream()))
                {
                    int targetWidth = 800;
                    int targetHeight = 600;
                    int quality = 60; // image quality (0-100)

                    // Resize the image while maintaining the aspect ratio
                    image.Mutate(x => x.Resize(new ResizeOptions
                    {
                        Size = new Size(targetWidth, targetHeight),
                        Mode = ResizeMode.Max
                    }));

                    // Compress and save the image as JPEG
                    var encoder = new JpegEncoder
                    {
                        Quality = quality
                    };

                    using (var memoryStream = new MemoryStream())
                    {
                        image.Save(memoryStream, encoder);
                        lakesighting.ImageData = memoryStream.ToArray();
                    }
                }
            }

            await _service.AddNewLakeSightingAsync(lakesighting);

            return RedirectToAction(nameof(Index));
        }




    }
}
