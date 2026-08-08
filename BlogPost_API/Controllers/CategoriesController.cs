using BlogPost_Models.Data.DTOs;
using Blogpost_Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost_API.Controllersi
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

            //return Ok("Category Created Successfully With Name "+dto.Name);
            return Ok(new
            {
               success = true,
                message = $"Category '{dto.Name}' created successfully. "

            });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var category = await _categoriservice.GetAllCategoryservice();

            return Ok(category);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCategoryByID(Guid id)
        {
            var category = await _categoriservice.GetCategoryByIDService(id);

            if(category == null)
            {
                return NotFound("Category Not Found for this ID: " + id);
            }

            return Ok(category);
        }

            [HttpPut]   
            [Route("UpdateCategory/{id:guid}")]

            public async Task<IActionResult> UpdateCategoryBtID(UpdateCategoryDTO dto,Guid id)  
            {
                await _categoriservice.UpdateCategoryService(id,dto);
                return Ok("Employee Updated Successfully");
            }

        [HttpDelete]
        [Route("Deletecategory/{id:guid}")]
        public async Task<IActionResult> DeleteCategoryByID(Guid id)
        {
            await _categoriservice.DeleteCategoryService(id);
            return Ok("Category Deleted Successfully");
        }


    }
}
