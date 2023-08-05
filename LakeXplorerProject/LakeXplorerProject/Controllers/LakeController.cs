using LakeXplorerProject.Data.Services;
using LakeXplorerProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace LakeXplorerProject.Controllers
{
    public class LakeController : Controller
    {

        private readonly ILakeServices _service;
        private readonly IWebHostEnvironment _webHostEnvironment;

     
        public LakeController(ILakeServices service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var allLakes = await _service.GetAllAsync();

            return View(allLakes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var lakeDetails = await _service.GetLakeByIdAsync(id);
            if (lakeDetails == null) return View("Not Found");
            return View(lakeDetails);
        }

        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Create(Lake lake)
        //{
        //    if (!ModelState.IsValid) return View(lake);

        //    await _service.AddNewLakeAsync(lake);

        //    Debug.WriteLine("Lake has been added");

        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(Lake lake, IFormFile imageFile)
        //{
        //    if (!ModelState.IsValid) return View(lake);

        //    // Nëse përdoruesi ka ngarkuar fotografi
        //    if (imageFile != null && imageFile.Length > 0)
        //    {
        //        // Krijoj një lokacion për ruajtjen e fotosë në server
        //        string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

        //        // Krijoj folderin nëse nuk ekziston
        //        if (!Directory.Exists(uploadFolder))
        //            Directory.CreateDirectory(uploadFolder);

        //        // Gjenero një emër unik për fotografinë
        //        string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;

        //        // Krijojë pathin e plotë për ruajtjen e fotosë
        //        string filePath = Path.Combine(uploadFolder, uniqueFileName);

        //        // Ruaj fotonë në server
        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await imageFile.CopyToAsync(stream);
        //        }

        //        // Vendosni emrin e fajllit në modelin e Lake për ta ruajtur në bazën e të dhënave
        //        lake.Image = uniqueFileName;

        //    }

        //    await _service.AddNewLakeAsync(lake);

        //    Debug.WriteLine("Lake has been added");

        //    return RedirectToAction(nameof(Index));
        //}




        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Lake lake)
        {
            if (!ModelState.IsValid)
            {
                return View(lake);
            }

            // If the user has uploaded an image
            if (lake.ImageFile != null && lake.ImageFile.Length > 0)
            {
                using (var image = Image.Load(lake.ImageFile.OpenReadStream()))
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
                        lake.ImageData = memoryStream.ToArray();
                    }
                }
            }

            await _service.AddNewLakeAsync(lake);

            return RedirectToAction(nameof(Index));
        }


        //[HttpPost]
        //public async Task<IActionResult> Create([FromForm] Lake lake)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(lake);
        //    }

        //    // If the user has uploaded an image
        //    if (lake.ImageFile != null && lake.ImageFile.Length > 0)
        //    {







        //        using (var memoryStream = new MemoryStream())
        //        {
        //            await lake.ImageFile.CopyToAsync(memoryStream);
        //            lake.ImageData = memoryStream.ToArray();
        //        }



        //    }

        //    await _service.AddNewLakeAsync(lake);

        //    Debug.WriteLine("Lake has been added");

        //    return RedirectToAction(nameof(Index));
        //}


        public async Task<IActionResult> Edit(int id)
        {
            var lakeDetails = await _service.GetLakeByIdAsync(id);
            if (lakeDetails == null) return View("Not Found");
            return View(lakeDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Lake lake)
        {
            if (!ModelState.IsValid) return View(lake);
            if (id == lake.Id)
            {
                await _service.UpdateLakeAsync(lake);
                return RedirectToAction(nameof(Index));
            }
            return View(lake);
        }



        public async Task<IActionResult> Delete(int id)
        {
            var lakeDetails = await _service.GetLakeByIdAsync(id);
            if (lakeDetails == null) return View("Not Found");
            return View(lakeDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lakeDetails = await _service.GetLakeByIdAsync(id);
            if (lakeDetails == null) return View("Not Found");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }



    }
}
