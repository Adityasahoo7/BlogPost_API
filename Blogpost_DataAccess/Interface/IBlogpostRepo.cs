using BlogPost_API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpost_DataAccess.Interface
{
    public interface IBlogpostRepo
    {
        Task AddBlogRepo(Blogpost blogpost);
        Task<List<Blogpost>> GetallblogRepo();
       // Task<List<Blogpost>> Getallblogrepoadminv2();
    }
}
