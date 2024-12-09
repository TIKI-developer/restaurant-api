using Notes.WebApi.Middleware;
using Restaurant.Application;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Interfaces;
using Restaurant.Persistence;
using Restaurant.Security;
using Restaurant.Validation;
using Restaurant.Verification;
using Restaurant.WebApi.Extensions;
using System.Reflection;


namespace Restaurant.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

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
            services.AddApplication();
            services.AddControllers();
            //.AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            //});

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder
                            .WithOrigins(
                            "https://chipipi.tw1.ru")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAll", policy =>
            //    {
            //        policy.AllowAnyHeader();
            //        policy.AllowAnyMethod();
            //        policy.AllowAnyOrigin();
            //    });
            //});
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseCustomExceptionHandler();
            app.UseHttpsRedirection();
            app.UseCors("AllowSpecificOrigin");
            //app.UseCors("AllowAll");
            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.RoutePrefix = string.Empty;
                config.SwaggerEndpoint("swagger/v1/swagger.json", "Restaurant API");
            });
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