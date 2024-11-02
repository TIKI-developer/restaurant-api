using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Interfaces;


namespace Restaurant.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("AppDbConnectionString");

            services.AddDbContext<RestaurantDbContext>(options =>
            {
                //options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)); 
                options.UseSqlite(configuration.GetConnectionString("WebApiDatabase"));
            });


            services.AddScoped<IRestaurantDbContext>(provider => 
                provider.GetService<RestaurantDbContext>());

            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

            return services;
        }
    }
}
