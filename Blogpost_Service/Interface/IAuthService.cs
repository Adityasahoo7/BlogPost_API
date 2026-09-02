using BlogPost_Models.Data.DTOs.AuthDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpost_Service.Interface
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> LoginAsyncService(LoginRequestDTO request);
        Task<bool> RegisterAsyncService(RegisterRequestDTO request);
    }
}
