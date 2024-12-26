using FinanceGub.Application.Interfaces;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;
using Google.Apis.Auth;

namespace FinanceHub.Infrastructure.Services;

public class AuthService: IAuthService
{
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;

    public AuthService(IUserService userService, IJwtService jwtService)
    {
        _userService = userService;
        _jwtService = jwtService;
    }

    public async Task<(User user, string token)> LoginAsync(string email, string password)
    {
        var user = await _userService.GetUserByCredentialsAsync(email, password);
        if (user == null) throw new UnauthorizedAccessException("Invalid credentials");

        var token = _jwtService.GenerateToken(user);
        return (user, token);
    }

    public async Task<string> GoogleLoginAsync(string googleToken)
    {
        var payload = await GoogleJsonWebSignature.ValidateAsync(googleToken);
        var user = await _userService.GetUserByGoogleIdAsync(payload.Subject)
                   ?? await _userService.CreateUserFromGoogleAsync(payload);

        return _jwtService.GenerateToken(user);
    }
}