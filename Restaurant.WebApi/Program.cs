using Restaurant.Persistence;


namespace Restaurant.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var restaurantContext = serviceProvider.GetRequiredService<RestaurantDbContext>();
                    DbInitializer.Initialize(restaurantContext);
                }
                catch (Exception exception)
                {

                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureKestrel(options =>
                    {
                        options.ListenAnyIP(8080); 
                        options.ListenAnyIP(8443, listenOptions =>
                        {
                            listenOptions.UseHttps("/certs/cert.pem", "/certs/key.pem");
                        });
                    });
                });
        }
    }
}