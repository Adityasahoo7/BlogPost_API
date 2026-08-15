using BlogPost_API.Data;
using BlogPost_API.Data.Models;
using Blogpost_DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpost_DataAccess.Repositary
{
    public class BlogpostRepo : IBlogpostRepo
    {
        private readonly BlogPostDbContext _context;
        public BlogpostRepo(BlogPostDbContext context)
        {
            _context = context;
        }
        public async Task AddBlogRepo(Blogpost blogpost)
        {
            await _context.BlogPostDS.AddAsync(blogpost);
            await _context.SaveChangesAsync();

           // _context.BlogPostDS.FromSqlRaw
           
        }

        public async Task DeleteBlogRepo(Guid id)
        {
            var blog = await _context.BlogPostDS.FirstOrDefaultAsync(b => b.Id == id);

            if (blog != null)
            {
                _context.BlogPostDS.Remove(blog);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Blogpost>> GetallblogRepo()
        {
            return await _context.BlogPostDS.Include(b=>b.Categotys)
                .ToListAsync();

            //This is the collection "Categotys"

        }

        public async Task<Blogpost> GetByIdBlogRepo(Guid id)
        {
            return await _context.BlogPostDS.Include(b => b.Categotys).FirstOrDefaultAsync(b => b.Id == id);

        }

        public async Task UpdateBlogRepo(Blogpost blogpost)
        {
             _context.BlogPostDS.Update(blogpost);
            await _context.SaveChangesAsync();
        }

        //public async Task<List<Blogpost>> Getallblogrepoadminv2()
        //{
        //    return await _context.BlogPostDS.ToListAsync();
        //}
    }
}
