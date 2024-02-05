using Microsoft.AspNetCore.Mvc;

namespace ImageUploading.Views.Components.ImageUploader
{
    public class ImageUploaderViewComponent : ViewComponent
    {
        public ImageUploaderViewComponent()
        {
        }
        public IViewComponentResult Invoke(string FileName)
        {
            return View("Default", FileName);
        }
    }
}
