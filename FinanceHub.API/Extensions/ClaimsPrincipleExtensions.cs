using System.Security.Claims;

namespace FinanceHub.Extensions;

public static class ClaimsPrincipleExtensions
{
    public static string GetEmail(this ClaimsPrincipal user)
    {
        var email = user.FindFirstValue(ClaimTypes.Email);

        if (email == null) throw new Exception("Cannot get email from the token");

        return email;
    }
}