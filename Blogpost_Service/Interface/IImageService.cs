using BlogPost_Models.Data.DTOs.BlogImageDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpost_Service.Interface
{
    public interface IImageService
    {
        Task<IEnumerable<BlogImageDTO>> GetAllAsync();
        Task<BlogImageDTO> UploadAsync(IFormFile file, string fileName, string title);

    }
}
