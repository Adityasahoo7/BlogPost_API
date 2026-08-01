using BlogPost_API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPost_API.Data
{
    public class BlogPostDbContext:DbContext
    {
        public BlogPostDbContext(DbContextOptions<BlogPostDbContext> options):base(options)
        {
                
        }

        public DbSet<Blogpost> BlogPostDS { get; set; }
        public DbSet<Category> CategoryDS { get; set; }
    }
}
