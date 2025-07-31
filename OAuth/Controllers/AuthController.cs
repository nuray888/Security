using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OAuth.Entities;
using OAuth.Entities.Models;
using OAuth.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace OAuth.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
       
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var user =await  authService.RegisterAsync(request);
            if(user is null)
            {
                return BadRequest("Username is already exist");
            }
            return Ok(user);  
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login(UserDto request)
        {
            var result=await authService.LoginAsync(request);
            if(result is null)
            {
                return BadRequest("Username or password is wrong");
            }
            return Ok(result);
        }
        [Authorize]
        [HttpGet]
        public IActionResult AuthenticatedOnlyEndpoint()
        {
            return Ok("You are authenticated");
        }

        [Authorize(Roles ="Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("You are an admin");
        }

    }
}
