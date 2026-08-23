using BlogPost_Models.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Blogpost_DataAccess.Interface
{
    public interface IImageRepo
    {
        Task<BlogImage> Uploadrepo(IFormFile file, BlogImage blogimage);
        Task<IEnumerable<BlogImage>> GetAllAsync();
    }
}
