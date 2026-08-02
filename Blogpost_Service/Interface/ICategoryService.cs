using BlogPost_Models.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpost_Service.Interface
{
    public interface ICategoryService
    {

        Task Addcategory(CreateCategoryDTO dto);
    }
}
