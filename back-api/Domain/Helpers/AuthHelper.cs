using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace back_api.Domain.Helpers
{
    public class AuthHelper
    {
        public static string CreateToken(List<Claim> claimsList, IConfiguration configuration)
        {
            SymmetricSecurityKey signKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var a = configuration["Jwt:Issuer"];
            a = configuration["Jwt:Audience"];
            a = configuration["Jwt:Key"];

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                expires: DateTime.Now.AddHours(2),
                claims: claimsList,
                signingCredentials: new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
