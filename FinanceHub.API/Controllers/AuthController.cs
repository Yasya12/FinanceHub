using FinanceGub.Application.DTOs.Authentication;
using FinanceGub.Application.Interfaces;
using FinanceGub.Application.Interfaces.Serviсes;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthService authService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        try
        {
            var token = await _authService.LoginAsync(model.Email, model.Password);
            return Ok(new {token });
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.LogWarning(ex.Message);
            return Unauthorized(new { error = ex.Message });
        }
    }

    [HttpPost("google")]
    public async Task<IActionResult> GoogleLogin([FromBody] TokenRequest tokenRequest)
    {
        try
        {
            var token = await _authService.GoogleLoginAsync(tokenRequest.Token);
            return Ok(new { token });
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Google login failed");
            return Unauthorized(new { error = "Invalid Google Token" });
        }
    }
}
