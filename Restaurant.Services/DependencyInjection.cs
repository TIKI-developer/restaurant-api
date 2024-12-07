using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Interfaces;

namespace Restaurant.Validation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddValidation(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPhoneNumberValidator, PhoneNumberValidator>();
            services.AddScoped<IAddressValidator, AddressValidator>();

            return services;
        }
    }
}
