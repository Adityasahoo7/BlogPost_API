using Blogpost_DataAccess.Interface;
using BlogPost_Models.Data.DTOs.BlogImageDTO;
using BlogPost_Models.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private const long MaxFileSizeBytes = 10 * 1024 * 1024; // 10 MB
        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png" };

        private readonly IImageRepo _imagerepo;

        public ImagesController(IImageRepo imagerepo)
        {
            _imagerepo = imagerepo;
        }

        [HttpPost("UploadImage")]
        [RequestSizeLimit(MaxFileSizeBytes)]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadRequestDto request)
        {
            ValidateFileUpload(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blogimage = new BlogImage
            {
                FileExtension = Path.GetExtension(request.File.FileName).ToLowerInvariant(),
                FileName = request.FileName,
                Title = request.Title,
                DateCreated = DateTime.UtcNow
            };

            blogimage = await _imagerepo.Uploadrepo(request.File, blogimage);

            var response = new BlogImageDTO
            {
                Id = blogimage.Id,
                Title = blogimage.Title,
                DateCreated = blogimage.DateCreated,
                FileExtension = blogimage.FileExtension,
                FileName = blogimage.FileName,
                Url = blogimage.Url
            };

            return Ok(response);
        }

        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            if (request.File == null || request.File.Length == 0)
            {
                ModelState.AddModelError("File", "File is required.");
                return;
            }

            var extension = Path.GetExtension(request.File.FileName).ToLowerInvariant();

            if (!AllowedExtensions.Contains(extension))
            {
                ModelState.AddModelError("File", "Unsupported file format. Allowed: .jpg, .jpeg, .png");
            }

            if (request.File.Length > MaxFileSizeBytes)
            {
                ModelState.AddModelError("File", "File size can't be more than 10 MB.");
            }

            if (string.IsNullOrWhiteSpace(request.FileName))
            {
                ModelState.AddModelError("FileName", "File name is required.");
            }

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                ModelState.AddModelError("Title", "Title is required.");
            }
        }
    }
}