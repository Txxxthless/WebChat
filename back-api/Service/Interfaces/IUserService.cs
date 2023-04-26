using back_api.Domain.Entity;
using System.IdentityModel.Tokens.Jwt;

namespace back_api.Service.Interfaces
{
    public interface IUserService
    {
        Task<DataBaseResponse<Dictionary<string, string>>> Login(LoginViewModel loginViewModel);
        Task<DataBaseResponse<Dictionary<string, string>>> Register(RegisterViewModel registerViewModel);
    }
}
