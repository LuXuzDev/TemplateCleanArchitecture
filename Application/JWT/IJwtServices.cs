using Application.Auth;
using Domain.Modules.Users.Models;
using Microsoft.AspNetCore.Http;

namespace Application.JWT;

public interface IJwtServices
{
    
    string GenerateToken(User user);
    
    UserClaims? ExtractUserClaimsFromHttpContext(HttpContext context);
    
    UserClaims? GetUserClaimsFromToken(string token);
    
}