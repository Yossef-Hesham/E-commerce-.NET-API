using BLL.System;
using DAL.system;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthManager authManager) : ControllerBase
    {
        public static User user = new();

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {

            var user = await authManager.RegisterAnync(request);

            if (user is null)
            {
                return BadRequest("user is already exist !");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login(UserDto request)
        {

            var Bothtokens = await authManager.LoginAnync(request);

            if (Bothtokens is null)
            {
                return BadRequest("invalid username or password");
            }

            return Ok(Bothtokens);
        }

        [Authorize]
        [HttpGet]
        public ActionResult<string> get()
        {
            return Ok("you 're Authorized bro");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only")]
        public ActionResult<string> get2()
        {
            return Ok("you 're Admin bro");
        }


        [HttpPost("RefreshToken")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenDto request)
        {
            var result = await authManager.RefreshTokenAsync(request);
            if (result is null || result.AccessToken is null || result.RefreshToken is null)
                return Unauthorized("Invalid refresh token.");

            return Ok(result);
        }


    }
}
