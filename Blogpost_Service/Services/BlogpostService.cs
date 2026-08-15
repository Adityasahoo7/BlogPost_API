using BlogPost_API.Data.Models;
using Blogpost_DataAccess.Interface;
using BlogPost_Models.Data.DTOs;
using BlogPost_Models.Data.DTOs.BlogpostDTO;
using Blogpost_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpost_Service.Services
{
    public class BlogpostService : IBlogpostService
    {
        private readonly IBlogpostRepo _blogrepo;
        private readonly ICategories _categoryrepo;
        public BlogpostService(IBlogpostRepo blogrepo,ICategories categoryrepo)
        {
            _categoryrepo = categoryrepo;
            _blogrepo = blogrepo;
        }
        public async Task AddBlogservice(CreateBlogpostDTO dto)
        {
            var blog = new Blogpost
            {
                Title = dto.Title,
                ShortDescription = dto.ShortDescription,
                Content = dto.Content,
                UrlHandle = dto.UrlHandle,
                FeaturedImageURL = dto.FeaturedImageURL,
                DateCreated = DateTime.Now,
                Auther = dto.Auther,
                Isvisible = dto.Isvisible
               // Categotys= dto.Categotys
            };

            foreach(var item in dto.Categotys)
            {
                var existcategory = await _categoryrepo.GetByIdRepo(item);
                if(existcategory is not null)
                {
                    blog.Categotys.Add(existcategory);
                }
            }

            await _blogrepo.AddBlogRepo(blog);
           
        }

        public async Task<List<BlogpostDTO>> getallblogservice()
        {
            var allblog = await _blogrepo.GetallblogRepo();

            return allblog.Select(b => new BlogpostDTO
            {
                Id = b.Id,
                Title = b.Title,
                ShortDescription = b.ShortDescription,
                Content = b.Content,
                UrlHandle = b.UrlHandle,
                FeaturedImageURL = b.FeaturedImageURL,
                DateCreated = b.DateCreated,
                Auther = b.Auther,
                Isvisible = b.Isvisible,

                categories =b.Categotys.Select(e=>new CategoryDTO
                {
                    Id=e.Id,
                    Name=e.Name,
                    URLHandle=e.URLHandle
                }).ToList()

            }).ToList();
        }

        public async Task<List<ViewBlogpostAdminDTO>> getallblogserviceAdminV2()
        {
            var blogdata = await _blogrepo.GetallblogRepo();

            return blogdata.Select(data => new ViewBlogpostAdminDTO
            {
                Id=data.Id,
                Title=data.Title,
                ShortDescription=data.ShortDescription,
                Isvisible=data.Isvisible
            }).ToList();
        }

        public async Task<BlogpostDTO> getbyidblogservice(Guid id)
        {
            var blog = await _blogrepo.GetByIdBlogRepo(id);

            if (blog == null)
            {
                throw new Exception("No blog data found on This iD : " + id);
            }

            return new BlogpostDTO
            {
                Id = blog.Id,
                Title = blog.Title,
                ShortDescription = blog.ShortDescription,
                Content = blog.Content,
                UrlHandle = blog.UrlHandle,
                FeaturedImageURL = blog.FeaturedImageURL,
                DateCreated = blog.DateCreated,
                Auther = blog.Auther,
                Isvisible = blog.Isvisible,

                categories = blog.Categotys.Select(c => new CategoryDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    URLHandle = c.URLHandle

                }).ToList()


            };
        }
    }
}
