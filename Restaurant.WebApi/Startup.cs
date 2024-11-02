using System.Reflection;
using Notes.WebApi.Middleware;
using Restaurant.Application;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Interfaces;
using Restaurant.Persistence;
using Restaurant.WebApi.Extensions;


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
            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddControllers();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSpecificOrigin",
            //        builder =>
            //        {
            //            builder
            //                .WithOrigins("https://restaurant-web-frontend-n8390m1rt-tiki-developers-projects.vercel.app")
            //                .AllowAnyMethod()
            //                .AllowAnyHeader()
            //                .AllowCredentials();
            //        });
            //});

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomExceptionHandler();
            app.UseHttpsRedirection();
            //app.UseCors("AllowSpecificOrigin");
            app.UseCors("AllowAll");
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