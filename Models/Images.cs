using System.ComponentModel.DataAnnotations.Schema;

namespace ImageUploading.Models
{
    public class Images
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
