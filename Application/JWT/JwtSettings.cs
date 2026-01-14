namespace Application.Auth;

public class JwtSettings
{
    
    public required string SecretKey { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public int ExpirationInMinutes { get; set; } = 60;
    public int RefreshTokenExpirationInMinutes { get; set; } = 43200;
    
    
}