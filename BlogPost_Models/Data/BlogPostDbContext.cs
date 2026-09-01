using BlogPost_API.Data.Models;
using BlogPost_Models.Data.Models;
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

        public DbSet<BlogImage> BlogImageDS { get; set; }
        public DbSet<Users> UsersDS { get; set; }
    }
}
