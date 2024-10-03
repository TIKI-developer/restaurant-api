using Microsoft.EntityFrameworkCore;
using Restaurant.Domain;

namespace Restaurant.Application.Interfaces
{
    public interface IDishDbContext
    {
        DbSet<Dish> Dishes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
