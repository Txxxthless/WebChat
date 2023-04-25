using back_api.DAL.Interfaces;
using back_api.Domain.Entity;
using back_api.Domain.Helpers;
using back_api.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace back_api.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;
        private IConfiguration _configuration;
        public UserService(IRepository<User> userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public async Task<DataBaseResponse<string>> Login(LoginViewModel loginViewModel)
        {
            DataBaseResponse<string> response = new DataBaseResponse<string>();
            try
            {
                User user = await _userRepository.GetAll().FirstOrDefaultAsync(
                    user => user.Name == loginViewModel.Name);

                if (user == null)
                {
                    throw new Exception("User not found");
                }

                if (user.Password != PasswordHelper.HashPassword(loginViewModel.Password))
                {
                    throw new Exception("Incorrect password");
                }

                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name)
                };

                string token = AuthHelper.CreateToken(claims, _configuration);

                response.StatusCode = 200;
                response.Data = token;
                return response;
            }
            catch (Exception ex)
            {
                response.Description = ex.Message;
                response.StatusCode = 500;
                return response;
            }
        }
        public async Task<DataBaseResponse<string>> Register(RegisterViewModel registerViewModel)
        {
            DataBaseResponse<string> response = new DataBaseResponse<string>();
            try
            {
                User user = await _userRepository.GetAll().FirstOrDefaultAsync(
                    user => user.Name == registerViewModel.Name);

                if (user != null)
                {
                    throw new Exception("User exists");
                }

                user = new User();
                user.Name = registerViewModel.Name;
                user.Password = PasswordHelper.HashPassword(registerViewModel.Password);

                await _userRepository.CreateAsync(user);

                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name)
                };

                string token = AuthHelper.CreateToken(claims, _configuration);

                response.StatusCode = 200;
                response.Data = token;
                return response;
            }
            catch (Exception ex)
            {
                response.Description = ex.Message;
                response.StatusCode = 500;
                return response;
            }
        }
    }
}
