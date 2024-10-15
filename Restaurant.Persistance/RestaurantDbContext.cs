using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Cart;
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
        public DbSet<CartModel> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new DishConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
