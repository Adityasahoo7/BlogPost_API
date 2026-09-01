using BlogPost_Models.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpost_DataAccess.Interface
{
    public interface IUserRepo
    {
        Task<Users> getUsersByCredRepo(string username, string password);
        Task<bool> RegisterUserRepo(Users users);

    }
}
