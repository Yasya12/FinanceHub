using FinanceGub.Application.DTOs.Authentication;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Exceptions;
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
    
    [HttpPost("signup")]
    public async Task<IActionResult> Signup([FromBody] SignupDto model)
    {
        try
        {
            var (user, token) = await _authService.SignupAsync(model);
            return Ok(new { user, token });
        }
        catch (ValidationException ex)
        {
            _logger.LogWarning(ex, "Signup validation failed.");
            return BadRequest(new { error = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.LogWarning(ex, "Unauthorized access during signup.");
            return Unauthorized(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error during signup.");
            return StatusCode(500, new { error = "An unexpected error occurred." });
        }
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        try
        {
            var (user, token) = await _authService.LoginAsync(model.Email, model.Password);
            return Ok(new { user, token });
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
            var (user, token) = await _authService.GoogleLoginAsync(tokenRequest.Token);
            return Ok(new { user, token });
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Google login failed");
            return Unauthorized(new { error = "Invalid Google Token" });
        }
    }
}
