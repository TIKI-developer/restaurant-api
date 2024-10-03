namespace Restaurant.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(DishDbContext dishDbContext)
        {
            dishDbContext.Database.EnsureCreated();
        }
    }
}
