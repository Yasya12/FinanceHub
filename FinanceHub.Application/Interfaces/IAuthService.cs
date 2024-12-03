namespace FinanceGub.Application.Interfaces;

public interface IAuthService
{
    Task<string> LoginAsync(string email, string password);
    Task<string> GoogleLoginAsync(string token);
}