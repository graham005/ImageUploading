using ImageUploading.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImageUploading.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ImageDbContext _context;

        public ImagesController(ImageDbContext context,IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;
        }
        public IActionResult Index()
        {
            List<Images> images = _context.images.ToList();
            return View(images);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Images images = new Images();
            return View(images);
        }
        [HttpPost]
        public ActionResult Create(Images images)
        {
                string uniqueFileName = UploadedFile(images);
                images.ImageUrl = uniqueFileName;
                _context.Attach(images);
                _context.Entry(images).State = EntityState.Added;
                _context.SaveChanges();
                return RedirectToAction("Index");
           
        }
        private string UploadedFile(Images images)
        {
            string? uniqueFileName = null;
            if (images.Image != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + images.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    images.Image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;

        }
    }
}

