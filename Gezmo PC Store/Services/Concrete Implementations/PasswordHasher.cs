using System.Security.Cryptography;
using System.Text;

namespace Gezmo_PC_Store.Services;

public class PasswordHasher:IPasswordHasher
{
    
    public static string ComputeSHA256(string input)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes); // Outputs hash as a hex string
        }
    }

    public string HashPassword(string password)
    {
        return ComputeSHA256(password);
    }
}