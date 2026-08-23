using BlogPost_API.Data;
using Blogpost_DataAccess.Interface;
using BlogPost_Models.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpost_DataAccess.Repositary
{
    public class ImageRepository : IImageRepo
    {
        private readonly IWebHostEnvironment _webhostenv;
        private readonly IHttpContextAccessor _httpcontentaccessor;
        private readonly BlogPostDbContext _context;
        public ImageRepository(IWebHostEnvironment webenviroment, 
            IHttpContextAccessor accessor,
            BlogPostDbContext context)
        {
            _webhostenv = webenviroment;
            _httpcontentaccessor = accessor;
            _context = context;
                
        }


        public async Task<IEnumerable<BlogImage>> GetAllAsync()
        {
            return await _context.BlogImageDS
                .AsNoTracking()
                .OrderByDescending(x => x.DateCreated)
                .ToListAsync();
        }
        public async Task<BlogImage> Uploadrepo(IFormFile file, BlogImage blogimage)
        {
            var localpath = Path.Combine(_webhostenv.ContentRootPath, "Images", $"{blogimage.FileName}{blogimage.FileExtension}");

            using var stream = new FileStream(localpath, FileMode.Create);
            await file.CopyToAsync(stream);

            var request = _httpcontentaccessor.HttpContext.Request;
            var urlpath = $"{request.Scheme}://{request.Host}{request.PathBase}/Images/{blogimage.FileName}{blogimage.FileExtension}";
            blogimage.Url = urlpath;

            await _context.BlogImageDS.AddAsync(blogimage);
            await _context.SaveChangesAsync();

            return blogimage;




        }
    }
}
