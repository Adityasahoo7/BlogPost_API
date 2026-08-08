using BlogPost_API.Data.Models;
using Blogpost_DataAccess.Interface;
using BlogPost_Models.Data.DTOs;
using Blogpost_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpost_Service.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategories _catagoryrepo;

        public CategoryService( ICategories category)
        {
            _catagoryrepo = category;
        }


        public async Task Addcategory(CreateCategoryDTO dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                URLHandle = dto.URLHandle
            };

          await _catagoryrepo.AddAsync(category);

            
        }

        public async Task DeleteCategoryService(Guid id)
        {
            await _catagoryrepo.DeleteCategoryRepo(id);
        }

        public async Task<List<CategoryDTO>> GetAllCategoryservice()
        {
            var gcategory = await _catagoryrepo.GetAllAsync();

            return gcategory.Select(e => new CategoryDTO
            {
                Id = e.Id,
                Name = e.Name,
                URLHandle = e.URLHandle
            }).ToList();
        }

        public async Task<getbyidCategoryDTO> GetCategoryByIDService(Guid id)
        {
            var category = await _catagoryrepo.GetByIdRepo(id);

            if (category == null)
            {
                throw new Exception("Category Not Found for this ID : " + id);
            }

            return new getbyidCategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                URLHandle=category.URLHandle
            };
        }

        public async Task UpdateCategoryService(UpdateCategoryDTO dto)
        {
            var category = await _catagoryrepo.GetByIdRepo(dto.Id);
            if (category == null)
            {
                throw new Exception("Category Not found For this ID : " + dto.Id);
            }

            category.Name = dto.Name;
            category.URLHandle = dto.URLHandle;

            await _catagoryrepo.UpdateCategoryRepo(category);
        }
    }
}
