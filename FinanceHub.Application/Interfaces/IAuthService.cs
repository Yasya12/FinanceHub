using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces;

public interface IAuthService
{
    Task<(User user, string token)> LoginAsync(string email, string password);
    Task<string> GoogleLoginAsync(string token);
}