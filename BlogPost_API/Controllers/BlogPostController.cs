using BlogPost_Models.Data.DTOs.BlogpostDTO;
using Blogpost_Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogpostService _service;
        public BlogPostController(IBlogpostService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("AddBlogpost")]
        public async Task<IActionResult> AddBlog(CreateBlogpostDTO dto)
        {
            await _service.AddBlogservice(dto);

            return Ok("Blog Added Successfully");
        }

        [HttpGet]
        [Route("GetAllBlogpost")]
        public async Task<IActionResult> getallblog()
        {
            var blog = await _service.getallblogservice();

            return Ok(blog);
        }

        [HttpGet]
        [Route("GetAllBlogpostV2")]
        public async Task<IActionResult> getallblogadminv2()
        {
            var blogv2 = await _service.getallblogserviceAdminV2();

            return Ok(blogv2);
        }
        [HttpGet]
        [Route("BetByIDBlog/{id:guid}")]
        public async Task<IActionResult> getbyblogid(Guid id)
        {
            var blog = await _service.getbyidblogservice(id);
            return Ok(blog);
        }

    }
}
