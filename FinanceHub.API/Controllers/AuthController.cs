using FinanceGub.Application.DTOs.Authentication;
using FinanceGub.Application.Interfaces.Serviсes;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

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
}