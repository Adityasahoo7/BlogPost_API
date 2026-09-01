using Blogpost_DataAccess.Interface;
using BlogPost_Models.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpost_DataAccess.Repositary
{
    public class UserRepository : IUserRepo
    {
        public Task<Users> getUsersByCredRepo(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterUserRepo(Users users)
        {
            throw new NotImplementedException();
        }
    }
}
