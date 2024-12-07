using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Interfaces;


namespace Restaurant.Security
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IAdminIdentityProvider, AdminIdentityProvider>();
            services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
            services.Configure<AdminOptions>(configuration.GetSection(nameof(AdminOptions)));

            return services;
        }
    }
}
