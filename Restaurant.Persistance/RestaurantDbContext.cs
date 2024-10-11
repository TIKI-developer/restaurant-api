using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Domain;
using Restaurant.Persistence.EntityTypeConfigurations;


namespace Restaurant.Persistence
{
    public class RestaurantDbContext : DbContext, IRestaurantDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Category> Categories {  get; set; }
        public DbSet<Order> Orders { get; set; }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new DishConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
