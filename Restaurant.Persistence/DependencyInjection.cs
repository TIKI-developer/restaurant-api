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
            var connectionString = configuration.GetConnectionString("DbConnection");

            services.AddDbContext<RestaurantDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IRestaurantDbContext>(provider =>
                provider.GetService<RestaurantDbContext>());

            return services;
        }
    }
}
