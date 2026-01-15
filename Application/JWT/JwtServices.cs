using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Application.JWT;

public sealed class JwtServices(JwtSettings jwtSettings, byte[] secretKey) : IJwtServices
{
    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Email, user.Email),
            new("IsActive", user.IsActive.ToString())
        };

        // Solo el rol importa - determina 
        if (user.Role is not null)
        {
            claims.Add(new Claim(ClaimTypes.Role, user.Role.Name));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(jwtSettings.ExpirationInMinutes),
            Issuer = jwtSettings.Issuer,
            Audience = jwtSettings.Audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(secretKey),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private ClaimsPrincipal? ValidateToken(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(secretKey)
            };
            var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
            return principal;
        }
        catch
        {
            return null;
        }
    }
    
    public UserClaims? GetUserClaimsFromToken(string token)
    {
        var principal = ValidateToken(token);
        if (principal is null)
            return null;
        var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdClaim, out var userId))
            return null;
        return new UserClaims
        {
            UserId = userId,
            UserName = principal.FindFirst(ClaimTypes.Name)?.Value,
            Role = principal.FindFirst(ClaimTypes.Role)?.Value,
            UserEmail = principal.FindFirst(ClaimTypes.Email)?.Value,
        };
    }
    
    
    public UserClaims? ExtractUserClaimsFromHttpContext(HttpContext httpContext)
    {
        
        var authHeader = httpContext.Request.Headers.Authorization.FirstOrDefault();
        
        if(string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            return null;
        
        var token = authHeader["Bearer ".Length..].Trim();
        return GetUserClaimsFromToken(token);
        
    }
    
}