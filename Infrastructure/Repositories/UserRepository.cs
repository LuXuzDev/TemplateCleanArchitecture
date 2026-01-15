using Domain.Modules.Users.Models;
using Domain.Modules.Users.Repository;


namespace Infrastructure.Repositories;

public class UserRepository : RepositoryGeneric<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

}
