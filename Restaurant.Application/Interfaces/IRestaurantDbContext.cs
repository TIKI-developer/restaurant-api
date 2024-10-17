using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Category;
using Restaurant.Domain.Dish;
using Restaurant.Domain.Order;
using Restaurant.Domain.User;


namespace Restaurant.Application.Interfaces
{
    public interface IRestaurantDbContext
    {
        DbSet<UserModel> Users { get; set; }
        DbSet<DishModel> Dishes { get; set; }
        DbSet<CategoryModel> Categories { get; set; }
        DbSet<OrderModel> Orders { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
