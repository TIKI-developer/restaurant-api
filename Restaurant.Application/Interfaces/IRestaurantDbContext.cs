using Microsoft.EntityFrameworkCore;
using Restaurant.Domain;

namespace Restaurant.Application.Interfaces
{
    public interface IRestaurantDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Dish> Dishes { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Order> Orders { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
