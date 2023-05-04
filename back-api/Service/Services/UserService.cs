using back_api.DAL.Interfaces;
using back_api.Domain.Entity;
using back_api.Domain.Helpers;
using back_api.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace back_api.Service.Services
{
    public class UserService : IUserService
    {
        private UserManager<IdentityUser> _userManager;
        private IConfiguration _configuration;
        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<DataBaseResponse<string>> Login(LoginViewModel loginViewModel)
        {
            DataBaseResponse<string> response = new DataBaseResponse<string>();
            try
            {
                IdentityUser user = await _userManager.FindByNameAsync(loginViewModel.Name);

                if (user == null)
                {
                    throw new Exception("User does not exist");
                }

                bool isCorrectPassword = await _userManager.CheckPasswordAsync(
                    user, loginViewModel.Password);

                if (!isCorrectPassword)
                {
                    throw new Exception("Incorrect password");
                }

                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                };

                string token = AuthHelper.CreateToken(claims, _configuration);
                response.Data = token;
                response.Succeeded = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Description = ex.Message;
                response.Succeeded = false;
                return response;
            }
        }
        public async Task<DataBaseResponse<string>> Register(RegisterViewModel registerViewModel)
        {
            DataBaseResponse<string> response = new DataBaseResponse<string>();
            try
            {
                IdentityUser user = await _userManager.FindByNameAsync(registerViewModel.Name);

                if (user != null)
                {
                    throw new Exception("User already exists");
                }

                user = new IdentityUser()
                {
                    UserName = registerViewModel.Name
                };

                IdentityResult creation = await _userManager.CreateAsync(user, registerViewModel.Password);

                if (creation.Succeeded)
                {
                    List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                };
                    string token = AuthHelper.CreateToken(claims, _configuration);
                    response.Data = token;
                    response.Succeeded = true;
                    return response;
                }
                else
                {
                    throw new Exception("Something went wrong");
                }
            }
            catch (Exception ex)
            {
                response.Description = ex.Message;
                response.Succeeded = false;
                return response;
            }
        }
    }
}
