using back_api.Domain.Entity;
using System.IdentityModel.Tokens.Jwt;

namespace back_api.Service.Interfaces
{
    public interface IUserService
    {
        Task<DataBaseResponse<string>> Login(LoginViewModel loginViewModel);
        Task<DataBaseResponse<string>> Register(RegisterViewModel registerViewModel);
    }
}
