using LakeXplorerProject.Data.Services;
using LakeXplorerProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace LakeXplorerProject.Controllers
{
    public class LakeSightingController : Controller
    {

        private readonly ILakeSightingService _service;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public LakeSightingController(ILakeSightingService service, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

       
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var lakeSightings = await _service.GetLakeSightingsByUserId(user.Id);

            return View(lakeSightings);

        }
        public async Task<IActionResult> AllLakeSightings()
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

            var user = await _userManager.GetUserAsync(User);

            await _service.AddNewLakeSightingAsync(lakesighting, user.Id);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            var lakeSightingDetails = await _service.GetLakeSightingByIdAsync(id);

            if (lakeSightingDetails == null) return View("Not Found");
            return View(lakeSightingDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var lakeDetails = await _service.GetLakeSightingByIdAsync(id);
            if (lakeDetails == null) return View("Not Found");

            var lakeDropdownsData = await _service.GetNewLakeDropdownsValues();
            ViewBag.Lake = new SelectList(lakeDropdownsData.Lakes, "Id", "Name");

            return View(lakeDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, LakeSighting lakesighting)
        {
            if (!ModelState.IsValid) return View(lakesighting);
            if (id == lakesighting.Id)
            {
                await _service.UpdateLakeSightingAsync(lakesighting);
                return RedirectToAction(nameof(Index));
            }

            var lakeDropdownsData = await _service.GetNewLakeDropdownsValues();

            ViewBag.Lake = new SelectList(lakeDropdownsData.Lakes, "Id", "Name");

            return View(lakesighting);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var lakesightingDetails = await _service.GetLakeSightingByIdAsync(id);
            if (lakesightingDetails == null) return View("Not Found");
            return View(lakesightingDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lakeDetails = await _service.GetLakeSightingByIdAsync(id);
            if (lakeDetails == null) return View("Not Found");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }



    }
}
