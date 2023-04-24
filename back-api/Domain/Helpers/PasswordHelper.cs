using System.Security.Cryptography;
using System.Text;

namespace back_api.Domain.Helpers
{
    public class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            using(SHA256 coder = SHA256.Create())
            {
                byte[] hashBytes = coder.ComputeHash(
                    Encoding.UTF8.GetBytes(password));
                string hashedResult = BitConverter.ToString(hashBytes).Replace("-","").ToLower();
                return hashedResult;
            }
        }
    }
}
