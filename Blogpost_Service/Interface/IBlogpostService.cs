using BlogPost_Models.Data.DTOs.BlogpostDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpost_Service.Interface
{
    public interface IBlogpostService
    {
        Task AddBlogservice(CreateBlogpostDTO dto);
        Task<List<BlogpostDTO>> getallblogservice();
        Task<List<ViewBlogpostAdminDTO>> getallblogserviceAdminV2();
        Task<BlogpostDTO> getbyidblogservice(Guid id);

        Task UpdateBlogService(Guid id, UpdateBlogpostDTO dto);

        Task DeleteBlogService(Guid id);
    }
}
