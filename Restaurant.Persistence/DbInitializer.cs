namespace Restaurant.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(RestaurantDbContext restaurantDbContext)
        {
            restaurantDbContext.Database.EnsureCreated();
        }
    }
}
