using Microsoft.AspNetCore.Http;

namespace Application.Auth;

public interface IJwtServices
{
    
    string GenerateToken(User user);
    
    UserClaims? ExtractUserClaimsFromHttpContext(HttpContext context);
    
    UserClaims? GetUserClaimsFromToken(string token);
    
}