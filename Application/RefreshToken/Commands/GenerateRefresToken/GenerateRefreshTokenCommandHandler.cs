using System.Security.Cryptography;
using System.Text;
using Application.Auth;
using FastEndpoints;

namespace Application.RefreshToken.Commands.GenerateRefresToken;

public class GenerateRefreshTokenCommandHandler : ICommandHandler<GenerateRefreshTokenCommand, string>
{
    
    //private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly JwtSettings _jwtSettings;

    public GenerateRefreshTokenCommandHandler(//IRefreshTokenRepository refreshTokenRepository,
                                              JwtSettings jwtSettings)
    {
        //_refreshTokenRepository = refreshTokenRepository;
        _jwtSettings = jwtSettings;
    }

    public async Task<string> ExecuteAsync(GenerateRefreshTokenCommand command, CancellationToken ct)
    {
        var req = command.Request;
        using var sha256 = SHA256.Create();
        var refreshToken = GenerateRandonString(_jwtSettings.SecretKey);
        var refreshTokenHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(refreshToken));
        DateTime created = DateTime.UtcNow;
        DateTime expired = DateTime.UtcNow.AddMinutes(_jwtSettings.RefreshTokenExpirationInMinutes);

        /*var RefreshToken = new Domain.RefreshToken
        {
            Id = Guid.NewGuid(),
            UserId = req,
            TokenHash = Convert.ToBase64String(refreshTokenHash),
            CreatedAt = created,
            ExpiresAt = expired,
        };
        await _refreshTokenRepository.CreateRefreshToken(RefreshToken,ct);*/
        
        return refreshToken;
    }

    private string GenerateRandonString(string tokenKey)
    {
        const int length = 32;
        string chars = tokenKey;

        var result = new StringBuilder(length);
        var buffer = new byte[length];

        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(buffer);

        for (int i = 0; i < length; i++)
        {
            result.Append(chars[buffer[i] % chars.Length]);
        }

        return result.ToString();
        
    }
    
}