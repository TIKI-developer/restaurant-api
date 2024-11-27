using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Interfaces;

namespace Restaurant.Verification
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddVerification(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<INumberVerifier, NumberVerifier>();
            services.Configure<SmsRuOptions>(configuration.GetSection(nameof(SmsRuOptions)));

            return services;
        }
    }
}
