namespace FinanceHub.Infrastructure.Helpers;
using BCrypt.Net;

public class PasswordHasher
{
    public static string HashPassword(string password)
    {
        return BCrypt.HashPassword(password);
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Verify(password, hashedPassword);
    }
} 