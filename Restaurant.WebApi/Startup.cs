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
            //            builder.WithOrigins("http://26.227.223.79:5173")
            //                   .AllowAnyMethod()
            //                   .AllowAnyHeader()
            //                   .AllowCredentials();
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

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.RoutePrefix = string.Empty;
                config.SwaggerEndpoint("swagger/v1/swagger.json", "Restaurant API");
            });
            app.UseAuthentication();
            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseCors("AllowAll");
            //app.UseCors("AllowSpecificOrigin");
            app.UseAuthorization();
            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}