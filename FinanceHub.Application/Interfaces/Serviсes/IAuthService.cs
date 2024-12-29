using FinanceGub.Application.DTOs.User;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IAuthService
{
    Task<(GetUserDto user, string token)> LoginAsync(string email, string password);
    Task<string> GoogleLoginAsync(string token);
}