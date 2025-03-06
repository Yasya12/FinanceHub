using FinanceGub.Application.DTOs.Authentication;
using FinanceGub.Application.DTOs.User;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IAuthService
{
    Task<(GetUserDto user, string token)> SignupAsync(SignupDto signupDto);
    Task<(GetUserDto user, string token)> LoginAsync(string email, string password);
    Task<(GetUserDto user, string token)> GoogleLoginAsync(string token);
}