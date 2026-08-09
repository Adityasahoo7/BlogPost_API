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
    }
}
