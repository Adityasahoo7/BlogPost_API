using BlogPost_API.Data.Models;
using Blogpost_DataAccess.Interface;
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
        public BlogpostService(IBlogpostRepo blogrepo)
        {
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
            };

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
                Isvisible = b.Isvisible
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
    }
}
