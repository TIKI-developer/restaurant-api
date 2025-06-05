using Notes.WebApi.Middleware;
using Restaurant.Application;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Interfaces;
using Restaurant.Firebase;
using Restaurant.Persistence;
using Restaurant.Security;
using Restaurant.Validation;
using Restaurant.Verification;
using Restaurant.WebApi.Extensions;
using System.Reflection;

namespace Restaurant.WebApi
{
    public class Startup(IConfiguration configuration)
    {
        public IConfiguration Configuration { get; } = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IRestaurantDbContext).Assembly));
            });

            services.AddApiAuthentication(Configuration);
            services.AddValidation(Configuration);
            services.AddSecurity(Configuration);
            services.AddVerification(Configuration);
            services.AddPersistence(Configuration);
            services.AddFirebase();
            services.AddApplication();
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder
                            .WithOrigins(
                            "https://chipipi.tw1.ru",
                            "https://chipipi.ru",
                            "http://localhost:3000")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCustomExceptionHandler();
            app.UseCors("AllowSpecificOrigin");

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(config =>
                {
                    config.RoutePrefix = string.Empty;
                    config.SwaggerEndpoint("swagger/v1/swagger.json", "Restaurant API");
                    config.InjectStylesheet("/swagger-ui/SwaggerDark.css");
                });
            }
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}