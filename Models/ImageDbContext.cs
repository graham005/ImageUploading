using Microsoft.EntityFrameworkCore;

namespace ImageUploading.Models
{
    public class ImageDbContext : DbContext
    {
        public ImageDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Images> images { get; set; }
    }   
}
