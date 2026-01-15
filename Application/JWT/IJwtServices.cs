using Application.Auth;
using Microsoft.AspNetCore.Http;

namespace Application.JWT;

public interface IJwtServices
{
    
    string GenerateToken(User user);
    
    UserClaims? ExtractUserClaimsFromHttpContext(HttpContext context);
    
    UserClaims? GetUserClaimsFromToken(string token);
    
}