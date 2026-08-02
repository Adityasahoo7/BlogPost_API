using BlogPost_API.Data.Models;
using Blogpost_DataAccess.Interface;
using BlogPost_Models.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpost_Service.Services
{
    public class CategoryService
    {
        private readonly ICategories _catagoryrepo;

        public CategoryService( ICategories category)
        {
            _catagoryrepo = category;
        }


        public async Task<CategoryDTO> Addcategory(CreateCategoryDTO dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                URLHandle = dto.URLHandle
            };

            var response = await _catagoryrepo.AddAsync(category);

            return new CategoryDTO
            {
                Id = response.Id,
                Name = response.Name,
                URLHandle = response.URLHandle
            };
        }
    }
}
