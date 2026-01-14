namespace Api.DependencyInjection;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        /* #region Configuración JWT con validación
         services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
         var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();

         // ✅ Validación de configuración JWT
         if (jwtSettings == null)
             ExceptionHelper.ThrowConfiguration("JwtSettings no está configurado en appsettings.json");

         if (string.IsNullOrEmpty(jwtSettings!.SecretKey) || jwtSettings.SecretKey.Length < 32)
             ExceptionHelper.ThrowConfiguration("JWT SecretKey debe tener al menos 32 caracteres");
         #endregion*/

        return services;
    }
}
