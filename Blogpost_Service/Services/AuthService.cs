using Blogpost_DataAccess.Interface;
using BlogPost_Models.Data.DTOs.AuthDTO;
using BlogPost_Models.Data.Models;
using Blogpost_Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blogpost_Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepo _repo;
        private readonly IConfiguration _config;
        public AuthService(IUserRepo repo,IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }
        public async Task<LoginResponseDTO> LoginAsyncService(LoginRequestDTO request)
        {
            var user = await _repo.getUsersByCredRepo(request.Username, request.Password);
            if (user == null)
            {
                return null;
                    ;
            }



            var claims = new[]
             {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role) // e.g. "Admin", "User"
           };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: creds
            );
          
            return new LoginResponseDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Role = user.Role
            };
        }

        public async Task<bool> RegisterAsyncService(RegisterRequestDTO request)
        {
            var user = new Users
            {
                Id = Guid.NewGuid(),
                Username=request.Username,
                Password=request.Password,
                Role="User"//Default User While Login
            };

            var result = await _repo.RegisterUserRepo(user);

            return result;
            
        }
    }
}
