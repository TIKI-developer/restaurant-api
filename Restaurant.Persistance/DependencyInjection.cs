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
            var connectionString = configuration["DbConnection"];

            services.AddDbContext<DishDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IDishDbContext>(provider => 
                provider.GetService<DishDbContext>());

            return services;
        }
    }
}
