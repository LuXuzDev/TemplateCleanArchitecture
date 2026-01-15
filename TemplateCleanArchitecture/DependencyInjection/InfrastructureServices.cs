using Domain.Modules.Users.Repository;
using Domain.Shared;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.DependencyInjection;
public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices
       (this IServiceCollection services, IConfiguration configuration)
    {
       #region Base de datos
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                 b => b.MigrationsAssembly("Infrastructure"))
            );
        #endregion


        #region Repositories

        services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
        services.AddScoped<IUserRepository, UserRepository>();

        #endregion


        return services;
    }
}

