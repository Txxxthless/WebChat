using back_api.Domain.Entity;
using back_api.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace back_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
         {
            DataBaseResponse<Dictionary<string, string>> response = await _userService.Register(registerViewModel);
            if (response.StatusCode == 200)
            {
                return Ok(response.Data);
            }
            return BadRequest();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            DataBaseResponse<Dictionary<string, string>> response = await _userService.Login(loginViewModel);
            if (response.StatusCode == 200)
            {
                return Ok(response.Data);
            }
            return BadRequest();
        }

        [HttpGet]
        [Authorize]
        public IActionResult LoginTest()
        {
            return Ok();
        }
    }
}
