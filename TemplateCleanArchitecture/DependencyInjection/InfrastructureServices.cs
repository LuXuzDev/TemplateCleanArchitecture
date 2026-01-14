namespace Api.DependencyInjection;
public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices
       (this IServiceCollection services, IConfiguration configuration)
    {
       /* #region Base de datos
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                 b => b.MigrationsAssembly("Infrastructure"))
            );
        #endregion*/

        //services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}

