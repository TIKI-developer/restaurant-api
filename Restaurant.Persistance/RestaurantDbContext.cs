using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Category;
using Restaurant.Domain.Dish;
using Restaurant.Domain.Order;
using Restaurant.Domain.User;
using Restaurant.Persistence.EntityTypeConfigurations;


namespace Restaurant.Persistence
{
    public class RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : DbContext(options), IRestaurantDbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<DishModel> Dishes { get; set; }
        public DbSet<CategoryModel> Categories {  get; set; }
        public DbSet<OrderModel> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            //modelBuilder.ApplyConfiguration(new ClientProfileConfiguration());
            //modelBuilder.ApplyConfiguration(new ClientCartConfiguration());
            modelBuilder.ApplyConfiguration(new DishConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
