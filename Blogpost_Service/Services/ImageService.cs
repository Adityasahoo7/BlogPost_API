using Blogpost_DataAccess.Interface;
using BlogPost_Models.Data.DTOs.BlogImageDTO;
using BlogPost_Models.Data.Models;
using Blogpost_Service.Interface;
using Microsoft.AspNetCore.Http;

namespace Blogpost_Service.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepo _imagerepo;

        public ImageService(IImageRepo imagerepo)
        {
            _imagerepo = imagerepo;
        }

        public async Task<IEnumerable<BlogImageDTO>> GetAllAsync()
        {
            var images = await _imagerepo.GetAllAsync();
            return images.Select(MapToDto).ToList();
        }

        public async Task<BlogImageDTO> UploadAsync(IFormFile file, string fileName, string title)
        {
            var blogimage = new BlogImage
            {
                FileExtension = Path.GetExtension(file.FileName).ToLowerInvariant(),
                FileName = fileName,
                Title = title,
                DateCreated = DateTime.UtcNow
            };

            blogimage = await _imagerepo.Uploadrepo(file, blogimage);

            return MapToDto(blogimage);
        }

        private static BlogImageDTO MapToDto(BlogImage image)
        {
            return new BlogImageDTO
            {
                Id = image.Id,
                Title = image.Title,
                FileName = image.FileName,
                FileExtension = image.FileExtension,
                Url = image.Url,
                DateCreated = image.DateCreated
            };
        }
    }
}