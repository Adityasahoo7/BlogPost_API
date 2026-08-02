using BlogPost_API.Data;
using BlogPost_API.Data.Models;
using Blogpost_DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpost_DataAccess.Repositary
{
    public class CategoriesRepository:ICategories
    {
        private readonly BlogPostDbContext _context;
        public CategoriesRepository(BlogPostDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            await _context.CategoryDS.AddAsync(category);
            await _context.SaveChangesAsync();

           // return category;

        }
    }
}
