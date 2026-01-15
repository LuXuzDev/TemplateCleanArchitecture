using Domain.Modules.RefreshTokens.Models;
using Domain.Modules.RefreshTokens.Repository;


namespace Infrastructure.Repositories;

public class RefreshTokenRepository : RepositoryGeneric<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(AppDbContext context) : base(context)
    {
    }
}