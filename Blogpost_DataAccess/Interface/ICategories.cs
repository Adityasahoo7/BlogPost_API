using BlogPost_API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpost_DataAccess.Interface
{
    public interface ICategories
    {
        Task AddAsync(Category category);
        Task<List<Category>> GetAllAsync();
    }
}
