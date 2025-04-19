using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Interfaces
{
    public interface IRestaurantDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Verification> Verifications { get; set; }
        DbSet<Dish> Dishes { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<Promotion> Promotions { get; set; }
        DbSet<SavedAddress> SavedAddresses { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
