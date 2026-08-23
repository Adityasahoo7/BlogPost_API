using BlogPost_Models.Data.DTOs.BlogImageDTO;
using Blogpost_Service.Interface;
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

        private readonly IImageService _imageservice;

        public ImagesController(IImageService imageservice)
        {
            _imageservice = imageservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            var images = await _imageservice.GetAllAsync();
            return Ok(images);
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

            var response = await _imageservice.UploadAsync(
                request.File, request.FileName, request.Title);

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