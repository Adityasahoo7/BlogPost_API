using BlogPost_API.Data;
using Blogpost_DataAccess.Interface;
using BlogPost_Models.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpost_DataAccess.Repositary
{


    public class UserRepository : IUserRepo
    {
        private readonly BlogPostDbContext _context;
        public UserRepository(BlogPostDbContext context)
        {
            _context = context;
                
        }



        public async Task<Users> getUsersByCredRepo(string username, string password)
        {

            try
            {
                var user = await _context.UsersDS.FirstOrDefaultAsync(u => u.Username == username);

                if (user == null)
                {
                    return null;
                }
                if (user.Password == password)
                {
                    return user;
                }
                else
                {
                    return null;
                }



            }
            catch (Exception ex)
            {
                throw;
            }
        
        }

        public async Task<bool> RegisterUserRepo(Users users)
        {

            var exists = await _context.UsersDS.AnyAsync(u => u.Username == users.Username);
            if (exists)
            {
                return false;
            }
            await _context.UsersDS.AddAsync(users);
            await _context.SaveChangesAsync();
            return true;

        
        
        }
    }
}
