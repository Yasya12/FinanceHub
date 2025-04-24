using FinanceGub.Application.DTOs.Authentication;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService, ILogger<AuthController> logger) : ControllerBase
{
    //TODO: see if i need to use all of this layers - controller - authservice - userservice 
    [HttpPost("signup")]
    public async Task<IActionResult> Signup([FromBody] SignupDto model)
    {
        try
        {
            var (user, token) = await authService.SignupAsync(model);
            return Ok(new { user, token });
        }
        catch (ValidationException ex)
        {
            logger.LogWarning(ex, "Signup validation failed.");
            return BadRequest(new { error = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            logger.LogWarning(ex, "Unauthorized access during signup.");
            return Unauthorized(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error during signup.");
            return StatusCode(500, new { error = "An unexpected error occurred." });
        }
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        try
        {
            var (user, token) = await authService.LoginAsync(model.Email, model.Password);
            return Ok(new { user, token });
        }
        catch (UnauthorizedAccessException ex)
        {
            logger.LogWarning(ex.Message);
            return Unauthorized(new { error = ex.Message });
        }
    }

    [HttpPost("google")]
    public async Task<IActionResult> GoogleLogin([FromBody] TokenRequest tokenRequest)
    {
        try
        {
            var (user, token) = await authService.GoogleLoginAsync(tokenRequest.Token);
            return Ok(new { user, token });
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "Google login failed");
            return Unauthorized(new { error = "Invalid Google Token" });
        }
    }
}
