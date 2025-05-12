using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FinanceHub.Infrastructure.Services;

public class JwtService(IConfiguration config, UserManager<User> userManager) : IJwtService
{
    public async Task<string> GenerateToken(User user)
    {
        var jwtKey = config["JwtKey"] ?? throw new InvalidOperationException("JwtKey is not configured properly.");
        //  if (jwtKey.Length < 64) throw new Exception("JYour jwtKey needs to be longer");

        //optional
        var jwtIssuer = config["JwtIssuer"] ??
                        throw new InvalidOperationException("JwtIssuer is not configured properly.");
        ;
        var jwtAudience = config["JwtAudience"] ??
                          throw new InvalidOperationException("JwtAudience is not configured properly.");
        ;

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        if (user.Email == null) throw new Exception("No email fr user");
        
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
            //new (ClaimTypes.Name, user.Username),
            //new (ClaimTypes.Role, user.Role)
        };

        var roles = await userManager.GetRolesAsync(user);
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(7),
            SigningCredentials = creds,
            //optional
            Issuer = jwtIssuer,
            Audience = jwtAudience
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}