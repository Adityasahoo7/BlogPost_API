using BlogPost_Models.Data.DTOs.AuthDTO;
using Blogpost_Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }


        [Authorize]
        [HttpPost("LoginUser")]
        public async Task<IActionResult> Login(LoginRequestDTO request)
        {
            var result = await _service.LoginAsyncService(request);


            if (result == null)
            {
                return Unauthorized(new
                {
                    status = 401,
                    message = "Invalid Username and password"
                });
            }

            else
            {
                return Ok(new
                {
                    status = 200,
                    message = "Login Successfully",
                    data = result
                });
            }
        }

        [Authorize]
        [HttpPost("ResisterUser")]
        public async Task<IActionResult> Register(RegisterRequestDTO request)
        {
            var result = await _service.RegisterAsyncService(request);

            if (result)
            {
                return Ok(new
                {
                    status = 200,
                    message = "Register Successfully"
                });
            }
            else
            {
                return Conflict(new
                {
                    status = 409,
                    message = "Username Already Exist"
                });
            }
        }


    }
}
