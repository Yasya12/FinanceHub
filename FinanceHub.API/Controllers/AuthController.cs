using FinanceGub.Application.DTOs.Authentication;
using FinanceGub.Application.Interfaces.Serviсes;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtService;
    private readonly IUserService _userService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IJwtService jwtService, IUserService userService, ILogger<AuthController> logger)
    {   
        _jwtService = jwtService;
        _userService = userService;
        _logger = logger;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto model)
    {
        var user = await _userService.GetUserByCredentialsAsync(model.Email, model.Password);
    
        if (user != null)
        {
            _logger.LogDebug($"Attempting to generate token for user: {user.Username}");
            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }

        return Unauthorized();
    }
    
    [HttpPost("google")]
    public async Task<IActionResult> GoogleLogin([FromBody] TokenRequest tokenRequest)
    {
        _logger.LogInformation("Received Google login request");
        try
        {
            _logger.LogInformation("Validating Google token");
            // Перевіряємо токен через Google API
            var payload = await GoogleJsonWebSignature.ValidateAsync(tokenRequest.Token);

            // Шукаємо користувача за Google ID (Subject)
            var user = await _userService.GetUserByGoogleIdAsync(payload.Subject);
            
            // Якщо користувач не знайдений, створюємо нового
            if (user == null)
            {
                user = await _userService.CreateUserFromGoogleAsync(payload);
            }

            // Генеруємо токен для користувача
            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }
        catch (InvalidJwtException)
        {
            _logger.LogInformation("Validating Google token");
            return Unauthorized("Invalid Google Token");
        }
    }
}