using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FinanceGub.Application.Identity;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace FinanceHub.Infrastructure.Services;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<JwtService> _logger;

    public JwtService(IConfiguration configuration, ILogger<JwtService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }
    
    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtKey = _configuration["JwtKey"];
        var jwtIssuer = _configuration["JwtIssuer"];
        var jwtAudience = _configuration["JwtAudience"];

        _logger.LogDebug($"JwtKey length: {jwtKey?.Length ?? 0}");
        _logger.LogDebug($"JwtIssuer: {jwtIssuer}");
        _logger.LogDebug($"JwtAudience: {jwtAudience}");

        if (string.IsNullOrEmpty(jwtKey))
        {
            _logger.LogError("JwtKey is null or empty");
            throw new InvalidOperationException("JwtKey is not configured properly.");
        }

        if (string.IsNullOrEmpty(jwtIssuer))
        {
            _logger.LogError("JwtIssuer is null or empty");
            throw new InvalidOperationException("JwtIssuer is not configured properly.");
        }

        if (string.IsNullOrEmpty(jwtAudience))
        {
            _logger.LogError("JwtAudience is null or empty");
            throw new InvalidOperationException("JwtAudience is not configured properly.");
        }

        var key = Encoding.ASCII.GetBytes(jwtKey);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Aud, jwtAudience),
            new Claim(IdentityData.AdminUserClaimName, user.Role.ToLower() == "admin" ? "true" : "false")
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = jwtIssuer,
            Audience = jwtAudience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}