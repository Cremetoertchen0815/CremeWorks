using System.Security.Cryptography;
using System.Text;

namespace CremeWorks.Backend.Utils;

public class PasswordHash
{
    public static async Task<string> HashPasswordAsync(string password, byte[] salt)
    {
        using var saltedPassword = new MemoryStream();
        saltedPassword.Write(Encoding.UTF8.GetBytes(password));
        saltedPassword.Write(salt);

        // Hash the concatenated password and salt
        // & Concatenate the salt and hashed password for storage
        byte[] hashedPasswordWithSalt = new byte[SHA256.HashSizeInBytes + salt.Length];
        await SHA256.HashDataAsync(saltedPassword, hashedPasswordWithSalt);
        salt.CopyTo(hashedPasswordWithSalt.AsMemory(0, SHA256.HashSizeInBytes));

        return Convert.ToBase64String(hashedPasswordWithSalt);
    }

    public static byte[] GenerateSalt() => RandomNumberGenerator.GetBytes(16);
}
