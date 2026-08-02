using BlogPost_Models.Data.DTOs;
using Blogpost_Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoriservice;

        public CategoriesController(ICategoryService service)
        {
            _categoriservice = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategories(CreateCategoryDTO dto)
        {
            Console.WriteLine("Aditya Sahoo");
            await _categoriservice.Addcategory(dto);

            return Ok("Category Created Successfully With Name "+dto.Name);
        }

    }
}
